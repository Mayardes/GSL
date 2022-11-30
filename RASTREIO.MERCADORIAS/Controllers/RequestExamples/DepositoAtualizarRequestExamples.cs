﻿using Bogus;
using RASTREIOMERCADORIAS.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace RASTREIOMERCADORIAS.Controllers.RequestExemples
{
    public class DepositoAtualizarRequestExamples : IExamplesProvider<DepositoDto>
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
