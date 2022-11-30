﻿using Bogus;
using CALCULOFRETE.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace CALCULOFRETE.Controllers.RequestExemples
{
    public class DepositoCadastrarRequestExamples : IExamplesProvider<DepositoDto>
    {
        public DepositoDto GetExamples()
        {
            var faker = new Faker("pt_BR");

            return new DepositoDto()
            {
                Id = Guid.NewGuid(),
                Contato = faker.Person.Phone,
                Nome = faker.Person.FullName,
                Endereco = faker.Address.FullAddress()
            };
        }
    }
}
