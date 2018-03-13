// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcSandbox.Controllers
{
    public class HomeController : Controller
    {
        [ModelBinder]
        public string Id { get; set; }

        public IActionResult Index()
        {
            return View();
        }
    }

    public class DocumentationController : Controller
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;
        public DocumentationController(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            _apiExplorer = apiExplorer;
        }

        public IActionResult Index()
        {
            //return View(_apiExplorer);
            var parameterDescription = _apiExplorer.ApiDescriptionGroups.Items.Single().Items.Single().ParameterDescriptions.Single();
            var isBindingRequired = parameterDescription.ModelMetadata.IsBindingRequired;
            var isRequired = parameterDescription.ModelMetadata.IsRequired;
            return Content($"isBindingRequired: {isBindingRequired}, isRequired: {isRequired}");
        }
    }

    //[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ValuesController))]
    //[Route("api/[controller]")]
    //public class ValuesController : Controller
    //{
    //    // GET api/values
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }
    //}

    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(MyController))]
    [Route("My")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public void MyAction([BindRequired, Required] string queryParm)
        {

        }
    }
}
