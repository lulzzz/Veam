using Barebone.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Veam.EMS.Application;
using Veam.EMS.Application.EmpBasic;
using Veam.EMS.Application.EmpBasic.Command.EmpDocuments;
using Veam.EMS.Application.EmpBasic.Command.EmpGovtId;
using Veam.EMS.Application.EmpBasic.Command.EmpImages;
using Veam.EMS.Application.JobProfiel;
using Veam.EMS.Application.JobProfile;

namespace Veam.EMS.EmpBasic
{
    public partial class EmployeeController : BaseController
    {

        public async Task<IActionResult> Register(EmployeeRegisterVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<RegisterNewEmployeeCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                
                return View(SVM);
            }
        }

        public async Task<IActionResult> SaveHireInfo(HireInfoVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<SaveHireInfoCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }
        public async Task<IActionResult> Resign(ResignInfoVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<SaveResignInfoCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }
        public async Task<IActionResult> SaveGlobalIds(EmployeeGovtIdsVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<SaveGovtIdsCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }

        public async Task<IActionResult> SaveAddress(AddressVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddEmpAddressCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }

        public async Task<IActionResult> SaveContactDetails(ContactDetailVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<AddEmpContactCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }


        public async Task<IActionResult> UploadImage(ImageVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UploadEmpImageCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
        }
        public async Task<IActionResult> UploadDocuments(DocumentsVM SVM)
        {
            try
            {
                SVM.user = GetCurrentUserName();
                var command = Mapper.Map<UploadDocumentCommand>(SVM);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(SVM);
            }
            
        }
    }
}
