using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RemiteeCore.Models;

namespace RemiteeCore.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        RemiteeContext dbContext = new RemiteeContext();



        [HttpGet("[action]")]
        public IEnumerable<Payer> Payer()
        {
            return dbContext.Payer;
        }

        [HttpPost("[action]")]
        public Payer Payer([FromBody]PayerRequest entityRequest)
        {
            Payer entity = new Payer {
                Code = entityRequest.Code,
                Name = entityRequest.Name
            };
            var nEntity = dbContext.Payer.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        [HttpPut("[action]")]
        public Payer Payer([FromBody]PayerPutRequest entityRequest)
        {
            Payer entity = dbContext.Payer.Find(entityRequest.Id);
            
            entity.Code = entityRequest.Code;
            entity.Name = entityRequest.Name;
            
            var nEntity = dbContext.Payer.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        [HttpDelete("[action]")]
        public void Payer(int id)
        {
            Payer entity = dbContext.Payer.Find(id);
            if (entity != null)
            {
                var nEntity = dbContext.Payer.Remove(entity);
                dbContext.SaveChanges();
            }
            
        }


        [HttpGet("[action]")]
        public PayerBranch PayerBranchGetOne(int id)
        {
            return dbContext.PayerBranch.Find(id);
        }

        [HttpGet("[action]")]
        public IEnumerable<PayerBranch> PayerBranch()
        {
            return dbContext.PayerBranch;
        }

        [HttpPost("[action]")]
        public PayerBranch PayerBranch([FromBody]PayerBranchRequest entityRequest)
        {
            PayerBranch entity = new PayerBranch
            {
                Code = entityRequest.Code,
                Name = entityRequest.Name,
                FormattedAddress = entityRequest.FormattedAddress,
                PayerId = entityRequest.PayerId
            };
            var nEntity = dbContext.PayerBranch.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        [HttpPut("[action]")]
        public PayerBranch PayerBranch([FromBody]PayerBranchPutRequest entityRequest)
        {
            PayerBranch entity = dbContext.PayerBranch.Find(entityRequest.Id);

            entity.Code = entityRequest.Code;
            entity.Name = entityRequest.Name;
            entity.FormattedAddress = entityRequest.FormattedAddress;
            entity.PayerId = entityRequest.PayerId;

            var nEntity = dbContext.PayerBranch.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        [HttpDelete("[action]")]
        public void PayerBranch(int id)
        {
            PayerBranch entity = dbContext.PayerBranch.Find(id);
            if (entity != null)
            {
                var nEntity = dbContext.PayerBranch.Remove(entity);
                dbContext.SaveChanges();
            }

        }



        
    }
}
