#pragma checksum "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69a7a10bd9bcfef36ef9801c1da610e49e7f9266"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/editpatient/{id}")]
    public partial class EditPatient : EditPatientBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"row\"><div class=\"col-sm-1 float-sm-left\"><a href=\"/patients\">Back</a></div>\r\n    <div class=\"col-sm-10\"></div>\r\n    <div class=\"col-sm-1 float-sm-right\"><a href=\"#\">Profile</a></div></div>\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-md-6 m-auto");
#nullable restore
#line 19 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
         if (GetPatient == null)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "<p><em>Loading...</em></p>");
#nullable restore
#line 22 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(6);
            __builder.AddAttribute(7, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 25 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                     Patient

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 25 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                             SubmitForm

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(10);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(11, "\r\n\r\n        ");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "form-group row");
                __builder2.AddMarkupContent(14, "<label for=\"patientName\" class=\"col-sm-4 col-form-label\">\r\n                Name\r\n            </label>\r\n            ");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "id", "patientName");
                __builder2.AddAttribute(19, "class", "form-control");
                __builder2.AddAttribute(20, "placeholder", "Patient Name");
                __builder2.AddAttribute(21, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                        Patient.PatientName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.PatientName = __value, Patient.PatientName))));
                __builder2.AddAttribute(23, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.PatientName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_0(__builder2, 25, 26, 
#nullable restore
#line 36 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.PatientName

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n        ");
                __builder2.OpenElement(28, "div");
                __builder2.AddAttribute(29, "class", "form-group row");
                __builder2.AddMarkupContent(30, "<label for=\"age\" class=\"col-sm-4 col-form-label\">\r\n                Age\r\n            </label>\r\n            ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateInputNumber_1(__builder2, 33, 34, "age", 35, "form-control", 36, "Age", 37, 
#nullable restore
#line 45 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          Patient.Age

#line default
#line hidden
#nullable disable
                , 38, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Age = __value, Patient.Age)), 39, () => Patient.Age);
                __builder2.AddMarkupContent(40, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_2(__builder2, 41, 42, 
#nullable restore
#line 46 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.Age

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n        ");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "form-group row");
                __builder2.AddMarkupContent(46, "<label for=\"mobileNumber\" class=\"col-sm-4 col-form-label\">\r\n                Mobile Number\r\n            </label>\r\n            ");
                __builder2.OpenElement(47, "div");
                __builder2.AddAttribute(48, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(49);
                __builder2.AddAttribute(50, "id", "mobileNumber");
                __builder2.AddAttribute(51, "class", "form-control");
                __builder2.AddAttribute(52, "placeholder", "Mobile Number");
                __builder2.AddAttribute(53, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 55 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                        Patient.MobileNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(54, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.MobileNumber = __value, Patient.MobileNumber))));
                __builder2.AddAttribute(55, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.MobileNumber));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(56, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_3(__builder2, 57, 58, 
#nullable restore
#line 56 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.MobileNumber

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n        ");
                __builder2.OpenElement(60, "div");
                __builder2.AddAttribute(61, "class", "form-group row");
                __builder2.AddMarkupContent(62, "<label for=\"fullAddress\" class=\"col-sm-4 col-form-label\">\r\n                Address\r\n            </label>\r\n            ");
                __builder2.OpenElement(63, "div");
                __builder2.AddAttribute(64, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(65);
                __builder2.AddAttribute(66, "id", "fullAddress");
                __builder2.AddAttribute(67, "class", "form-control");
                __builder2.AddAttribute(68, "placeholder", "Full Address");
                __builder2.AddAttribute(69, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                            Patient.FullAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(70, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.FullAddress = __value, Patient.FullAddress))));
                __builder2.AddAttribute(71, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.FullAddress));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\r\n        ");
                __builder2.OpenElement(73, "div");
                __builder2.AddAttribute(74, "class", "form-group row");
                __builder2.AddMarkupContent(75, "<label for=\"patientHistory\" class=\"col-sm-4 col-form-label\">\r\n                History\r\n            </label>\r\n            ");
                __builder2.OpenElement(76, "div");
                __builder2.AddAttribute(77, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(78);
                __builder2.AddAttribute(79, "id", "patientHistory");
                __builder2.AddAttribute(80, "class", "form-control");
                __builder2.AddAttribute(81, "placeholder", "History");
                __builder2.AddAttribute(82, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 74 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                            Patient.PatientHistory

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(83, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.PatientHistory = __value, Patient.PatientHistory))));
                __builder2.AddAttribute(84, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.PatientHistory));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(85, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_4(__builder2, 86, 87, 
#nullable restore
#line 75 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.PatientHistory

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n        ");
                __builder2.OpenElement(89, "div");
                __builder2.AddAttribute(90, "class", "form-group row");
                __builder2.AddMarkupContent(91, "<label for=\"complain\" class=\"col-sm-4 col-form-label\">\r\n                Complain\r\n            </label>\r\n            ");
                __builder2.OpenElement(92, "div");
                __builder2.AddAttribute(93, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(94);
                __builder2.AddAttribute(95, "id", "complain");
                __builder2.AddAttribute(96, "class", "form-control");
                __builder2.AddAttribute(97, "placeholder", "Complain");
                __builder2.AddAttribute(98, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 84 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                            Patient.Complain

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(99, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Complain = __value, Patient.Complain))));
                __builder2.AddAttribute(100, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.Complain));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(101, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_5(__builder2, 102, 103, 
#nullable restore
#line 85 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.Complain

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n        ");
                __builder2.OpenElement(105, "div");
                __builder2.AddAttribute(106, "class", "form-group row");
                __builder2.AddMarkupContent(107, "<label for=\"rxTreatment\" class=\"col-sm-4 col-form-label\">\r\n                Rx(Treatment)\r\n            </label>\r\n            ");
                __builder2.OpenElement(108, "div");
                __builder2.AddAttribute(109, "class", "col-sm-8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputTextArea>(110);
                __builder2.AddAttribute(111, "id", "rxTreatment");
                __builder2.AddAttribute(112, "class", "form-control");
                __builder2.AddAttribute(113, "placeholder", "RxTreatment");
                __builder2.AddAttribute(114, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 94 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                            Patient.RxTreatment

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(115, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.RxTreatment = __value, Patient.RxTreatment))));
                __builder2.AddAttribute(116, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Patient.RxTreatment));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(117, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_6(__builder2, 118, 119, 
#nullable restore
#line 95 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.RxTreatment

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(120, "\r\n        ");
                __builder2.OpenElement(121, "div");
                __builder2.AddAttribute(122, "class", "form-group row");
                __builder2.AddMarkupContent(123, "<label for=\"nextAppointmentDate\" class=\"col-sm-4 col-form-label\">\r\n                Next Visit\r\n            </label>\r\n            ");
                __builder2.OpenElement(124, "div");
                __builder2.AddAttribute(125, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateInputDate_7(__builder2, 126, 127, "nextAppointmentDate", 128, "form-control", 129, "Next Appointment Date", 130, 
#nullable restore
#line 104 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                        Patient.NextAppointmentDate

#line default
#line hidden
#nullable disable
                , 131, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.NextAppointmentDate = __value, Patient.NextAppointmentDate)), 132, () => Patient.NextAppointmentDate);
                __builder2.AddMarkupContent(133, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_8(__builder2, 134, 135, 
#nullable restore
#line 105 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.NextAppointmentDate

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(136, "\r\n        ");
                __builder2.OpenElement(137, "div");
                __builder2.AddAttribute(138, "class", "form-group row");
                __builder2.AddMarkupContent(139, "<label for=\"fees\" class=\"col-sm-4 col-form-label\">\r\n                Fees\r\n            </label>\r\n            ");
                __builder2.OpenElement(140, "div");
                __builder2.AddAttribute(141, "class", "col-sm-8");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateInputNumber_9(__builder2, 142, 143, "fees", 144, "form-control", 145, "Fees", 146, 
#nullable restore
#line 114 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          Patient.Fees

#line default
#line hidden
#nullable disable
                , 147, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Patient.Fees = __value, Patient.Fees)), 148, () => Patient.Fees);
                __builder2.AddMarkupContent(149, "\r\n                ");
                __Blazor.vagbhat.web.Pages.EditPatient.TypeInference.CreateValidationMessage_10(__builder2, 150, 151, 
#nullable restore
#line 115 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
                                          ()=>Patient.Fees

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(152, "\r\n        ");
                __builder2.AddMarkupContent(153, "<button type=\"submit\">Submit</button>");
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 120 "D:\project\git\vagbhat\vagbhat.web\Pages\EditPatient.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.vagbhat.web.Pages.EditPatient
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
