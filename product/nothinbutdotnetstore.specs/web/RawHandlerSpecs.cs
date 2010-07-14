 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RawHandlerSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             RawHandler>
         {
        
         }

         [Subject(typeof(RawHandler))]
         public class when_processing_an_incoming_http_context : concern
         {

             Establish c = () =>
             {
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();

                 request = new object();
                 http_context = ObjectMother.create_http_context();

                 request_factory.Stub(x => x.create_from(http_context)).Return(request);

             };

             Because b = () =>
                 sut.ProcessRequest(http_context);

             It should_dispatch_the_request_to_the_front_controller = () =>
                 front_controller.received(x => x.process(request));

             static FrontController front_controller;
             static object request;
             static HttpContext http_context;
             static RequestFactory request_factory;
         }
     }
 }
