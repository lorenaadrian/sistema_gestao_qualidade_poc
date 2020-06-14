using Microsoft.AspNetCore.Mvc;
using SistemaGestaoQualidade.WebApi.Contracts;
using SistemaGestaoQualidade.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SistemaGestaoQualidadeTest
{
    public class ComplianceControllerTest
    {
        ComplianceController _controller;
        ICatalogoNorma _catalogo;

        public ComplianceControllerTest()
        {
            _catalogo = new ComplianceFake();
            _controller = new ComplianceController(_catalogo);
        }

        [Fact]
        public void GetNormaAsync_RecuperandoNorma()
        {
            var result = _controller.GetNorma("");
            Assert.NotNull(result);
        }

    }
}
