#pragma checksum "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbdcecc969fda356a025accb70d720277baf901e"
// <auto-generated/>
#pragma warning disable 1591
namespace vagbhat.web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using vagbhat.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\project\git\vagbhat\vagbhat.web\_Imports.razor"
using vagbhat.web.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addpatient")]
    public partial class AddPatient : AddPatientBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"row\"><div class=\"col-sm-1 float-sm-left\"><a href=\"/\">Back</a></div>\r\n    <div class=\"col-sm-11\"><h3></h3></div></div>\r\n    ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "col-md-6 m-auto");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 14 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                         Patient

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 14 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                                 SubmitForm

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n\r\n            ");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "form-group row");
                __builder2.AddMarkupContent(11, "<label for=\"patientName\" class=\"col-sm-4 col-form-label\">\r\n                    Name\r\n                </label>\r\n                ");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(14);
                __builder2.AddAttribute(15, "id", "patientName");
                __builder2.AddAttribute(16, "class", "form-control");
                __builder2.AddAttribute(17, "placeholder", "Patient Name");
                __builder2.AddAttribute(18, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                            Patient.PatientName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.PatientName = __value, Patient.PatientName))));
                __builder2.AddAttribute(20, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.PatientName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_0(__builder2, 22, 23, 
#nullable restore
#line 25 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.PatientName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "class", "form-group row");
                __builder2.AddMarkupContent(27, "<label for=\"age\" class=\"col-sm-4 col-form-label\">\r\n                    Age\r\n                </label>\r\n                ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateInputNumber_1(__builder2, 30, 31, "age", 32, "form-control", 33, "Age", 34, 
#nullable restore
#line 34 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              Patient.Age

#line default
#line hidden
#nullable disable
                , 35, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Age = __value, Patient.Age)), 36, () => Patient.Age);
                __builder2.AddMarkupContent(37, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_2(__builder2, 38, 39, 
#nullable restore
#line 35 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.Age

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n            ");
                __builder2.OpenElement(41, "div");
                __builder2.AddAttribute(42, "class", "form-group row");
                __builder2.AddMarkupContent(43, "<label for=\"mobileNumber\" class=\"col-sm-4 col-form-label\">\r\n                    Mobile Number\r\n                </label>\r\n                ");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(46);
                __builder2.AddAttribute(47, "id", "mobileNumber");
                __builder2.AddAttribute(48, "class", "form-control");
                __builder2.AddAttribute(49, "placeholder", "Mobile Number");
                __builder2.AddAttribute(50, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                            Patient.MobileNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.MobileNumber = __value, Patient.MobileNumber))));
                __builder2.AddAttribute(52, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.MobileNumber));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_3(__builder2, 54, 55, 
#nullable restore
#line 45 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.MobileNumber

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\r\n            ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "form-group row");
                __builder2.AddMarkupContent(59, "<label for=\"fullAddress\" class=\"col-sm-4 col-form-label\">\r\n                    Address\r\n                </label>\r\n                ");
                __builder2.OpenElement(60, "div");
                __builder2.AddAttribute(61, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(62);
                __builder2.AddAttribute(63, "id", "fullAddress");
                __builder2.AddAttribute(64, "class", "form-control");
                __builder2.AddAttribute(65, "placeholder", "Full Address");
                __builder2.AddAttribute(66, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 54 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                                Patient.FullAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.FullAddress = __value, Patient.FullAddress))));
                __builder2.AddAttribute(68, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.FullAddress));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\r\n            ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "form-group row");
                __builder2.AddMarkupContent(72, "<label for=\"patientHistory\" class=\"col-sm-4 col-form-label\">\r\n                    History\r\n                </label>\r\n                ");
                __builder2.OpenElement(73, "div");
                __builder2.AddAttribute(74, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(75);
                __builder2.AddAttribute(76, "id", "patientHistory");
                __builder2.AddAttribute(77, "class", "form-control");
                __builder2.AddAttribute(78, "placeholder", "History");
                __builder2.AddAttribute(79, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                                Patient.PatientHistory

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(80, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.PatientHistory = __value, Patient.PatientHistory))));
                __builder2.AddAttribute(81, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.PatientHistory));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(82, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_4(__builder2, 83, 84, 
#nullable restore
#line 64 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.PatientHistory

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n            ");
                __builder2.OpenElement(86, "div");
                __builder2.AddAttribute(87, "class", "form-group row");
                __builder2.AddMarkupContent(88, "<label for=\"complain\" class=\"col-sm-4 col-form-label\">\r\n                    Complain\r\n                </label>\r\n                ");
                __builder2.OpenElement(89, "div");
                __builder2.AddAttribute(90, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(91);
                __builder2.AddAttribute(92, "id", "complain");
                __builder2.AddAttribute(93, "class", "form-control");
                __builder2.AddAttribute(94, "placeholder", "Complain");
                __builder2.AddAttribute(95, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 73 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                                Patient.Complain

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(96, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Complain = __value, Patient.Complain))));
                __builder2.AddAttribute(97, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Complain));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(98, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_5(__builder2, 99, 100, 
#nullable restore
#line 74 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.Complain

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(101, "\r\n            ");
                __builder2.OpenElement(102, "div");
                __builder2.AddAttribute(103, "class", "form-group row");
                __builder2.AddMarkupContent(104, "<label for=\"rxTreatment\" class=\"col-sm-4 col-form-label\">\r\n                    Rx(Treatment)\r\n                </label>\r\n                ");
                __builder2.OpenElement(105, "div");
                __builder2.AddAttribute(106, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(107);
                __builder2.AddAttribute(108, "id", "rxTreatment");
                __builder2.AddAttribute(109, "class", "form-control");
                __builder2.AddAttribute(110, "placeholder", "RxTreatment");
                __builder2.AddAttribute(111, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 83 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                                Patient.RxTreatment

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(112, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.RxTreatment = __value, Patient.RxTreatment))));
                __builder2.AddAttribute(113, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.RxTreatment));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(114, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_6(__builder2, 115, 116, 
#nullable restore
#line 84 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.RxTreatment

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(117, "\r\n            ");
                __builder2.OpenElement(118, "div");
                __builder2.AddAttribute(119, "class", "form-group row");
                __builder2.AddMarkupContent(120, "<label for=\"nextAppointmentDate\" class=\"col-sm-4 col-form-label\">\r\n                    Next Visit\r\n                </label>\r\n                ");
                __builder2.OpenElement(121, "div");
                __builder2.AddAttribute(122, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateInputDate_7(__builder2, 123, 124, "nextAppointmentDate", 125, "form-control", 126, "Next Appointment Date", 127, 
#nullable restore
#line 93 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                            Patient.NextAppointmentDate

#line default
#line hidden
#nullable disable
                , 128, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.NextAppointmentDate = __value, Patient.NextAppointmentDate)), 129, () => Patient.NextAppointmentDate);
                __builder2.AddMarkupContent(130, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_8(__builder2, 131, 132, 
#nullable restore
#line 94 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.NextAppointmentDate

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(133, "\r\n            ");
                __builder2.OpenElement(134, "div");
                __builder2.AddAttribute(135, "class", "form-group row");
                __builder2.AddMarkupContent(136, "<label for=\"fees\" class=\"col-sm-4 col-form-label\">\r\n                    Fees\r\n                </label>\r\n                ");
                __builder2.OpenElement(137, "div");
                __builder2.AddAttribute(138, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateInputNumber_9(__builder2, 139, 140, "fees", 141, "form-control", 142, "Fees", 143, 
#nullable restore
#line 103 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              Patient.Fees

#line default
#line hidden
#nullable disable
                , 144, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Fees = __value, Patient.Fees)), 145, () => Patient.Fees);
                __builder2.AddMarkupContent(146, "\r\n                    ");
                __Blazor.vagbhat.web.Pages.AddPatient.TypeInference.CreateValidationMessage_10(__builder2, 147, 148, 
#nullable restore
#line 104 "D:\project\git\vagbhat\vagbhat.web\Pages\AddPatient.razor"
                                              ()=>Patient.Fees

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(149, "\r\n            ");
                __builder2.AddMarkupContent(150, "<button type=\"submit\">Submit</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(151, "\r\n<br>");
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.vagbhat.web.Pages.AddPatient
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputDate_7<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputDate<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_8<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateInputNumber_9<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_10<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
