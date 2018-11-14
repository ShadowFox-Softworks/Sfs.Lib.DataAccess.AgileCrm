namespace Osw.Lib.DataAccess.AgileCrm.Test.Integration
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Processors;

    public class Test1
    {
        public void Testy()
        {
            var entity = new AgileCrmClientContactEntity
            {
                Address = null,
                StarValue = 0
            };

            var poop = new ValidationContext(entity);

            Validator.ValidateObject(entity, poop, true);

            var cp = new ContactProcessor(null, null, null);

            cp.CreateContactAsync(entity, CancellationToken.None).Wait();
        }
    }
}