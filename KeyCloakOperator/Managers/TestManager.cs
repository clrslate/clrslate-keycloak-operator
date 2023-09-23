using KeyCloakOperator.Entities;
using KubeOps.Operator.Controller.Results;

namespace KeyCloakOperator.Managers
{
    internal class TestManager : IManager<V1KeyCloakClientEntity>
    {
        private readonly ILogger<TestManager> _logger;

        public TestManager(ILogger<TestManager> logger) => _logger = logger;

        public Task<ResourceControllerResult?> ReconcileAsync(V1KeyCloakClientEntity entity)
        {
            _logger.LogDebug(nameof(ReconcileAsync));
            return Task.FromResult<ResourceControllerResult?>(null);
        }

        public Task StatusModifiedAsync(V1KeyCloakClientEntity entity)
        {
            _logger.LogDebug(nameof(StatusModifiedAsync));
            return Task.CompletedTask;
        }

        public Task DeletedAsync(V1KeyCloakClientEntity entity)
        {
            _logger.LogDebug(nameof(DeletedAsync));
            return Task.CompletedTask;
        }

        public Task FinalizedAsync(V1KeyCloakClientEntity entity)
        {
            _logger.LogDebug(nameof(FinalizedAsync));
            return Task.CompletedTask;
        }
    }
}
