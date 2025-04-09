using HandballManager.Data;
using HandballManager.Gameplay;
using System;
using System.Threading;

namespace HandballManager.Simulation.Core.Interfaces
{
    /// <summary>
    /// Interface for the match engine that orchestrates the simulation of a handball match.
    /// </summary>
    public interface IMatchEngine
    {
        /// <summary>
        /// Simulates a complete handball match between two teams.
        /// </summary>
        /// <param name="homeTeam">The home team data.</param>
        /// <param name="awayTeam">The away team data.</param>
        /// <param name="homeTactic">The tactic for the home team.</param>
        /// <param name="awayTactic">The tactic for the away team.</param>
        /// <param name="seed">Optional random seed for deterministic simulation (-1 for time-based).</param>
        /// <param name="progress">Optional progress reporter.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>The match result containing score and statistics.</returns>
        MatchResult SimulateMatch(TeamData homeTeam, TeamData awayTeam, Tactic homeTactic, Tactic awayTactic,
                               int seed = -1, IProgress<float> progress = null, CancellationToken cancellationToken = default);
    }
}