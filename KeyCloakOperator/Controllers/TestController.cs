using KubeOps.Operator.Controller.Results;
using KubeOps.Operator.Controller;
using KubeOps.Operator.Rbac;
using KeyCloakOperator.Entities;
using KeyCloakOperator.Managers;
using MediatR;
using KeyCloakOperator.Extensions.MediatR;

namespace KeyCloakOperator.Controllers
{
    [EntityRbac(typeof(V1KeyCloakClientEntity), Verbs = RbacVerb.All)]
    public class TestController : IResourceController<V1KeyCloakClientEntity>
    {
        private readonly IManager<V1KeyCloakClientEntity> _manager;
        private readonly IMediator _mediator;

        public TestController(IManager<V1KeyCloakClientEntity> manager, IMediator mediator)
        {
            _manager = manager;
            _mediator = mediator;
        }

        public async Task<ResourceControllerResult?> ReconcileAsync(V1KeyCloakClientEntity entity) => await _mediator.OnReconciled(entity);

        public async Task StatusModifiedAsync(V1KeyCloakClientEntity entity) => _manager.StatusModifiedAsync(entity);

        public async Task DeletedAsync(V1KeyCloakClientEntity entity) => _manager.DeletedAsync(entity);
    }
}