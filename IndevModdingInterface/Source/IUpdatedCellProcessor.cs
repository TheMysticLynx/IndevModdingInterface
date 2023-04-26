using System.Threading;

namespace Modding
{
    //Does your cell implement update logic? If so, implement this interface.
    public interface IUpdatedCellProcessor
    {
        public void Step(CancellationToken cancellationToken);
    }
}