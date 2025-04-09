using UnityEngine;
using HandballManager.Data;
using HandballManager.Simulation.Core.Events;

namespace HandballManager.Simulation.Core
{
    /// <summary>
    /// Coordinates the match simulation process using a component-based approach.
    /// Uses dependency injection to get required services.
    /// </summary>
    public class MatchSimulationCoordinator : MonoBehaviour
    {
        // Injected dependencies
        private IMatchEngine _engine;
        private IPlayerAIService _aiService;
        private IEventBus _eventBus;
        
        /// <summary>
        /// Initializes the coordinator with the required dependencies.
        /// </summary>
        /// <param name="engine">The match engine service.</param>
        /// <param name="aiService">The player AI service.</param>
        /// <param name="eventBus">The event bus for publishing events.</param>
        public void Initialize(IMatchEngine engine, IPlayerAIService aiService, IEventBus eventBus)
        {
            _engine = engine;
            _aiService = aiService;
            _eventBus = eventBus;
            
            Debug.Log("MatchSimulationCoordinator initialized with injected dependencies.");
        }
        
        /// <summary>
        /// Simulates a match between two teams.
        /// </summary>
        /// <param name="home">The home team data.</param>
        /// <param name="away">The away team data.</param>
        public void SimulateMatch(TeamData home, TeamData away)
        {
            Debug.Log($"Starting match simulation: {home.Name} vs {away.Name}");
            
            // Initialize the match engine
            _engine.Initialize(home, away);
            
            // Publish match started event
            _eventBus.Publish(new MatchStartedEvent
            {
                HomeTeam = home,
                AwayTeam = away
            });
            
            // Run the simulation until completion
            StartCoroutine(RunSimulation());
        }
        
        /// <summary>
        /// Coroutine to run the match simulation over time.
        /// </summary>
        private System.Collections.IEnumerator RunSimulation()
        {
            while (!_engine.MatchCompleted)
            {
                // Process AI decisions for all players
                _aiService.ProcessDecisions();
                
                // Advance the match simulation
                _engine.Advance(Time.deltaTime);
                
                // Yield to allow the game to remain responsive
                yield return null;
            }
            
            // Match is complete, publish the result
            _eventBus.Publish(new MatchCompletedEvent
            {
                Result = _engine.GetMatchResult()
            });
            
            Debug.Log("Match simulation completed.");
        }
    }
    
    /// <summary>
    /// Event fired when a match starts.
    /// </summary>
    public class MatchStartedEvent : EventBase
    {
        /// <summary>
        /// Gets or sets the home team.
        /// </summary>
        public TeamData HomeTeam { get; set; }
        
        /// <summary>
        /// Gets or sets the away team.
        /// </summary>
        public TeamData AwayTeam { get; set; }
    }
    
    /// <summary>
    /// Interface for the player AI service.
    /// </summary>
    public interface IPlayerAIService
    {
        /// <summary>
        /// Processes decisions for all AI-controlled players.
        /// </summary>
        void ProcessDecisions();
    }
    
    /// <summary>
    /// Interface for the match engine.
    /// </summary>
    public interface IMatchEngine
    {
        /// <summary>
        /// Gets whether the match is completed.
        /// </summary>
        bool MatchCompleted { get; }
        
        /// <summary>
        /// Initializes the match engine with the teams.
        /// </summary>
        /// <param name="home">The home team data.</param>
        /// <param name="away">The away team data.</param>
        void Initialize(TeamData home, TeamData away);
        
        /// <summary>
        /// Advances the match simulation by the specified time.
        /// </summary>
        /// <param name="deltaTime">The time to advance the simulation by.</param>
        void Advance(float deltaTime);
        
        /// <summary>
        /// Gets the match result.
        /// </summary>
        /// <returns>The match result.</returns>
        MatchResult GetMatchResult();
    }
}