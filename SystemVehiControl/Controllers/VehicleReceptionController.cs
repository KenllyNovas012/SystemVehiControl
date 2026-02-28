using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Dto;
using SystemVehiControl.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SystemVehiControl.Controllers
{
    public class VehicleReceptionController : Controller
    {
        private readonly VehixControlContext _context;

        public VehicleReceptionController(VehixControlContext context)
        {

            _context = context;
        }
        // GET: VehicleReception
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            var receptions = await _context.VehicleReceptions
                .Include(v => v.Client)
                .Include(v => v.Vehicle)
                .ToListAsync();

            return View(receptions);
        }

        // GET: VehicleReception/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var lastReception = await _context.VehicleReceptions
             .OrderByDescending(v => v.OrderNumber) // o por OrderNumber si prefieres
             .FirstOrDefaultAsync();

            string newOrderNumber = "ORD1001"; // Valor por defecto si no hay registros

            if (lastReception != null)
            {
                string lastOrderNumber = lastReception.OrderNumber; // ej: "ORD1003"

                // Extraer solo la parte numérica
                var numberPart = lastOrderNumber.Substring(3); // "1003"

                if (int.TryParse(numberPart, out int number))
                {
                    number++; // sumar 1
                    newOrderNumber = "ORD" + number.ToString("D4"); // ej: ORD1004 con 4 dígitos
                }
            }
            var model = new VehicleReceptionDto
            {
                OrderNumber = newOrderNumber
            };

            model.ReceptionDate = DateTime.Now;

            ViewData["NewOrderNumber"] = newOrderNumber;

            ViewData["ClientId"] = new SelectList(await _context.Clients.ToListAsync(), "Id", "FullName");

            ViewData["VehicleId"] = new SelectList(_context.Vehicles.OrderBy(v => v.LicensePlate), "VehicleId", "LicensePlate");

           ViewBag.DoorWindowOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Funcionan todos", Text = "Funcionan todos" },
                new SelectListItem { Value = "Funciona parcial", Text = "Funciona parcial" },
                new SelectListItem { Value = "No funcionan", Text = "No funcionan" }
            };

              ViewBag.DoorLockOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Funcionan todos", Text = "Funcionan todos" },
                new SelectListItem { Value = "Funciona parcial", Text = "Funciona parcial" },
                new SelectListItem { Value = "No funcionan", Text = "No funcionan" }
            };

            ViewBag.HornOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Bien", Text = "Bien" },
                new SelectListItem { Value = "Ronca", Text = "Ronca" },
                new SelectListItem { Value = "Mal", Text = "Mal" }
            };

            ViewBag.UpholsteryConditionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione un opción", Selected = true },
                new SelectListItem { Value = "Bueno", Text = "Bueno" },
                new SelectListItem { Value = "Medio", Text = "Medio" },
                new SelectListItem { Value = "Malo", Text = "Malo" },
            };

            ViewBag.RetrovisoresList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Seleccione", Value = "", Selected = true },
                new SelectListItem { Text = "Funcionan todos", Value = "Funcionan todos" },
                new SelectListItem { Text = "Funciona parcial", Value = "Funciona parcial" },
                new SelectListItem { Text = "No funcionan", Value = "No funcionan" }
            };

            ViewBag.CentroAroList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Seleccione", Value = "", Selected = true },
                new SelectListItem { Text = "Completa", Value = "Completa" },
                new SelectListItem { Text = "Incompleta", Value = "Incompleta" }
            };
            return View(model);
        }

        public IActionResult PrintView(int id)
        {
            var reception = _context.VehicleReceptions
                .Include(r => r.Client)
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.VehicleReceptionId == id);

            if (reception == null)
                return NotFound();

            return View("PrintView", reception);
        }

        // POST: VehicleReception/Create
        [HttpPost]
        public async Task<IActionResult> Create(VehicleReceptionDto model)
        {
            // Configuración
            var allowedImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            long maxImageSize = 5 * 1024 * 1024; // 5MB

            var allowedVideoExtensions = new[] { ".mp4", ".mov", ".avi", ".mkv" };
            long maxVideoSize = 50 * 1024 * 1024; // 50MB

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/exterior");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var photos = new List<Photo>();
                var photoFiles = new[] { model.ExteriorPhoto1, model.ExteriorPhoto2, model.ExteriorPhoto3, model.ExteriorPhoto4, model.ExteriorPhoto5 };
                foreach (var file in photoFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

                        if (!allowedImageExtensions.Contains(ext))
                        {
                            ModelState.AddModelError("ExteriorPhotos", "Una de las imágenes exteriores tiene un formato inválido.");
                            return View(model);
                        }

                        if (file.Length > maxImageSize)
                        {
                            ModelState.AddModelError("ExteriorPhotos", "Una de las imágenes exteriores excede el tamaño permitido de 5MB.");
                            return View(model);
                        }

                        string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                        string filePath = Path.Combine(uploadPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        photos.Add(new Photo
                        {
                            FileName = uniqueFileName,
                            Url = "/uploads/exterior/" + uniqueFileName,
                            Description = "Imagen de vehiculo"
                        });
                    }
                }
                if (model.ExteriorVideo != null && model.ExteriorVideo.Length > 0)
                {
                    var ext = Path.GetExtension(model.ExteriorVideo.FileName).ToLowerInvariant();

                    if (!allowedVideoExtensions.Contains(ext))
                    {
                        ModelState.AddModelError("InteriorVideo", "Formato de video inválido. Use MP4, MOV, AVI o MKV.");
                        return View(model);
                    }

                    if (model.ExteriorVideo.Length > maxVideoSize)
                    {
                        ModelState.AddModelError("InteriorVideo", "El video excede el tamaño máximo permitido de 50MB.");
                        return View(model);
                    }

                    string uniqueVideoName = $"{Guid.NewGuid()}_{Path.GetFileName(model.ExteriorVideo.FileName)}";
                    string videoPath = Path.Combine(uploadPath, uniqueVideoName);

                    using (var stream = new FileStream(videoPath, FileMode.Create))
                    {
                        await model.ExteriorVideo.CopyToAsync(stream);
                    }

                    photos.Add(new Photo
                    {
                        FileName = uniqueVideoName,
                        Url = "/uploads/interior/" + uniqueVideoName,
                        Description = "Video interior del vehículo"
                    });
                }



                var exteriorInspection = new ExteriorInspection
                {
                    RadioAntennaOk = model.RadioAntennaOk,
                    BeepersOk = model.BeepersOk,
                    SpareTirePresent = model.SpareTirePresent,
                    JackAndWrenchPresent = model.JackAndWrenchPresent,
                    AlarmWorking = model.AlarmWorking,
                    Photos = photos,
                    MirrorCondition =model.MirrorCondition,
                    HoopGame=model.HoopGame
                };
                _context.ExteriorInspections.Add(exteriorInspection);
                await _context.SaveChangesAsync();

                string interiorUploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/interior");
                if (!Directory.Exists(interiorUploadPath))
                {
                    Directory.CreateDirectory(interiorUploadPath);
                }

                var interiorPhotos = new List<Photo>();
                var interiorPhotoFiles = new[] { model.InteriorPhoto4, model.InteriorPhoto5, model.InteriorPhoto6, model.InteriorPhoto7, model.InteriorPhoto8 };
                foreach (var file in interiorPhotoFiles)
                {
                    if (file != null && file.Length > 0)
                    {

                        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

                        if (!allowedImageExtensions.Contains(ext))
                        {
                            ModelState.AddModelError("ExteriorPhotos", "Una de las imágenes exteriores tiene un formato inválido.");
                            return View(model);
                        }

                        if (file.Length > maxImageSize)
                        {
                            ModelState.AddModelError("ExteriorPhotos", "Una de las imágenes exteriores excede el tamaño permitido de 5MB.");
                            return View(model);
                        }

                        string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                        string filePath = Path.Combine(interiorUploadPath, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        interiorPhotos.Add(new Photo
                        {
                            FileName = uniqueFileName,
                            Url = "/uploads/interior/" + uniqueFileName,
                            Description = "Imagen de vehiculo"
                        });
                    }
                }
                if (model.Interiorvideo != null && model.Interiorvideo.Length > 0)
                {
                    var ext = Path.GetExtension(model.Interiorvideo.FileName).ToLowerInvariant();

                    if (!allowedVideoExtensions.Contains(ext))
                    {
                        ModelState.AddModelError("InteriorVideo", "Formato de video inválido. Use MP4, MOV, AVI o MKV.");
                        return View(model);
                    }

                    if (model.Interiorvideo.Length > maxVideoSize)
                    {
                        ModelState.AddModelError("InteriorVideo", "El video excede el tamaño máximo permitido de 50MB.");
                        return View(model);
                    }

                    string uniqueVideoName = $"{Guid.NewGuid()}_{Path.GetFileName(model.Interiorvideo.FileName)}";
                    string videoPath = Path.Combine(uploadPath, uniqueVideoName);

                    using (var stream = new FileStream(videoPath, FileMode.Create))
                    {
                        await model.Interiorvideo.CopyToAsync(stream);
                    }

                    interiorPhotos.Add(new Photo
                    {
                        FileName = uniqueVideoName,
                        Url = "/uploads/interior/" + uniqueVideoName,
                        Description = "Video interior del vehículo"
                    });
                }

                var interiorInspection = new InteriorInspection
                {
                    UpholsteryOk = model.UpholsteryOk,
                    LighterOk = model.LighterOk,
                    ACFunctionality = model.ACFunctionality,
                    RadioOk = model.RadioOk,
                    RadioSpeakersOk = model.RadioSpeakersOk,
                    Doorwindows = model.Doorwindows,
                    Doorlocks = model.Doorlocks,
                    Carhorn = model.Carhorn,
                    RearRightDoorOk = model.RearRightDoorOk,
                    ExternalHornOk = model.ExternalHornOk,
                    FloorMatCount = model.FloorMatCount,
                    EmergencyKitOk = model.EmergencyKitOk,
                    Photos = interiorPhotos
                };
                _context.InteriorInspections.Add(interiorInspection);
                await _context.SaveChangesAsync();

                var vehicleReception = new VehicleReception
                {
                    OrderNumber = model.OrderNumber,
                    ReceptionDate = model.ReceptionDate,
                    ReceptionTime = model.ReceptionTime,
                    ClientId = model.ClientId,
                    VehicleId = model.VehicleId,
                    PersonalItems = model.PersonalItems,
                    Observations = model.Observations,
                    VisitReason = model.VisitReason,
                    InteriorInspectionId = interiorInspection.Id,
                    ExteriorInspectionId = exteriorInspection.Id
                };
                _context.VehicleReceptions.Add(vehicleReception);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();  // 🔑 IMPORTANTE

                TempData["SuccessMessage"] = "Recepción de vehículo creada correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();  // 🔑 Para revertir si falla
                ModelState.AddModelError("", $"Ocurrió un error: {ex.Message}");
            }

            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", model.ClientId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", model.VehicleId);
            return View(model);
        }

        // GET: VehicleReception/Edit/5
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var reception = await _context.VehicleReceptions
                .Include(r => r.Client)
                .Include(r => r.Vehicle)
                .Include(r => r.InteriorInspection)
                .Include(r => r.ExteriorInspection)
                .FirstOrDefaultAsync(r => r.VehicleReceptionId == id);

                if (reception == null)
                {
                    return NotFound();
                }
                var exteriorPhotos = await _context.Photos
                    .Where(p => p.ExteriorInspectionId == reception.ExteriorInspectionId)
                    .Select(p => new InspectionImageDto
                    {
                        Id = p.PhotoId,
                        Url = p.Url,
                    }).ToListAsync();

                var InteriorInspection = await _context.Photos
                    .Where(p => p.InteriorInspectionId == reception.InteriorInspectionId)
                    .Select(p => new InspectionImageDto
                    {
                        Id = p.PhotoId,
                        Url = p.Url,
                    }).ToListAsync();

                var model = new VehicleReceptionDto
                {
                    VehicleReceptionId = reception.VehicleReceptionId,
                    OrderNumber = reception.OrderNumber,
                    ReceptionDate = reception.ReceptionDate,
                    ReceptionTime = reception.ReceptionTime,
                    ClientId = reception.ClientId,
                    VehicleId = reception.VehicleId,
                    PersonalItems = reception.PersonalItems,
                    Observations = reception.Observations,
                    VisitReason = reception.VisitReason,
                    UpholsteryOk = reception.InteriorInspection.UpholsteryOk,
                    LighterOk = reception.InteriorInspection.LighterOk,
                    ACFunctionality = reception.InteriorInspection.ACFunctionality,
                    RadioOk = reception.InteriorInspection.RadioOk,
                    RadioSpeakersOk = reception.InteriorInspection.RadioSpeakersOk,
                    Doorwindows = reception.InteriorInspection.Doorwindows,
                    Doorlocks = reception.InteriorInspection.Doorlocks,
                    Carhorn = reception.InteriorInspection.Carhorn,
                    RearRightDoorOk = reception.InteriorInspection.RearRightDoorOk,
                    ExternalHornOk = reception.InteriorInspection.ExternalHornOk,
                    FloorMatCount = reception.InteriorInspection.FloorMatCount,
                    EmergencyKitOk = reception.InteriorInspection.EmergencyKitOk,
                    RadioAntennaOk = reception.ExteriorInspection.RadioAntennaOk,
                    BeepersOk = reception.ExteriorInspection.BeepersOk,
                    SpareTirePresent = reception.ExteriorInspection.SpareTirePresent,
                    JackAndWrenchPresent = reception.ExteriorInspection.JackAndWrenchPresent,
                    AlarmWorking = reception.ExteriorInspection.AlarmWorking,
                    InteriorImages = InteriorInspection,
                    ExteriorImages = exteriorPhotos,
                    MirrorCondition=reception.ExteriorInspection.MirrorCondition,
                    HoopGame = reception.ExteriorInspection.HoopGame,
                    
                };


                ViewData["ClientId"] = new SelectList(await _context.Clients.ToListAsync(), "Id", "FullName");

                ViewData["VehicleId"] = new SelectList(_context.Vehicles.OrderBy(v => v.LicensePlate), "VehicleId", "LicensePlate");

                ViewBag.UpholsteryConditionList = new List<SelectListItem>
                {
                    new SelectListItem { Value = "", Text = "Seleccione el estado de la tapicería", Selected = true },
                    new SelectListItem { Value = "Bueno", Text = "Bueno" },
                    new SelectListItem { Value = "Medio", Text = "Medio" },
                    new SelectListItem { Value = "Malo", Text = "Malo" },
                };


                ViewBag.DoorWindowOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Funcionan todos", Text = "Funcionan todos" },
                new SelectListItem { Value = "Funciona parcial", Text = "Funciona parcial" },
                new SelectListItem { Value = "No funcionan", Text = "No funcionan" }
            };

                ViewBag.DoorLockOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Funcionan todos", Text = "Funcionan todos" },
                new SelectListItem { Value = "Funciona parcial", Text = "Funciona parcial" },
                new SelectListItem { Value = "No funcionan", Text = "No funcionan" }
            };

                ViewBag.HornOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione una opción", Selected = true },
                new SelectListItem { Value = "Bien", Text = "Bien" },
                new SelectListItem { Value = "Ronca", Text = "Ronca" },
                new SelectListItem { Value = "Mal", Text = "Mal" }
            };

                ViewBag.UpholsteryConditionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione un opción", Selected = true },
                new SelectListItem { Value = "Bueno", Text = "Bueno" },
                new SelectListItem { Value = "Medio", Text = "Medio" },
                new SelectListItem { Value = "Malo", Text = "Malo" },
            };

                ViewBag.RetrovisoresList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Seleccione", Value = "", Selected = true },
                new SelectListItem { Text = "Funcionan todos", Value = "Funcionan todos" },
                new SelectListItem { Text = "Funciona parcial", Value = "Funciona parcial" },
                new SelectListItem { Text = "No funcionan", Value = "No funcionan" }
            };

                ViewBag.CentroAroList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Seleccione", Value = "", Selected = true },
                new SelectListItem { Text = "Completa", Value = "Completa" },
                new SelectListItem { Text = "Incompleta", Value = "Incompleta" }
            };


                return View(model);  // 👈 Pasamos el modelo a la vista
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int id, VehicleReceptionDto model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var reception = await _context.VehicleReceptions
                    .Include(r => r.InteriorInspection)
                    .Include(r => r.ExteriorInspection)
                    .FirstOrDefaultAsync(r => r.VehicleReceptionId == id);

                if (reception == null)
                {
                    return NotFound();
                }

                // Actualizar VehicleReception
                reception.OrderNumber = model.OrderNumber;
                reception.ReceptionDate = model.ReceptionDate;
                reception.ReceptionTime = model.ReceptionTime;
                reception.ClientId = model.ClientId;
                reception.VehicleId = model.VehicleId;
                reception.PersonalItems = model.PersonalItems;
                reception.Observations = model.Observations;
                reception.VisitReason = model.VisitReason;

                // Actualizar ExteriorInspection
                reception.ExteriorInspection.RadioAntennaOk = model.RadioAntennaOk;
                reception.ExteriorInspection.BeepersOk = model.BeepersOk;
                reception.ExteriorInspection.SpareTirePresent = model.SpareTirePresent;
                reception.ExteriorInspection.JackAndWrenchPresent = model.JackAndWrenchPresent;
                reception.ExteriorInspection.AlarmWorking = model.AlarmWorking;
                reception.ExteriorInspection.MirrorCondition = model.MirrorCondition;
                reception.ExteriorInspection.HoopGame = model.HoopGame;
                _context.ExteriorInspections.Update(reception.ExteriorInspection);


                // Actualizar InteriorInspection
                reception.InteriorInspection.UpholsteryOk = model.UpholsteryOk;
                reception.InteriorInspection.LighterOk = model.LighterOk;
                reception.InteriorInspection.ACFunctionality = model.ACFunctionality;
                reception.InteriorInspection.RadioOk = model.RadioOk;
                reception.InteriorInspection.RadioSpeakersOk = model.RadioSpeakersOk;
                reception.InteriorInspection.Doorwindows = model.Doorwindows;
                reception.InteriorInspection.Doorlocks = model.Doorlocks;
                reception.InteriorInspection.Carhorn = model.Carhorn;
                reception.InteriorInspection.RearRightDoorOk = model.RearRightDoorOk;
                reception.InteriorInspection.ExternalHornOk = model.ExternalHornOk;
                reception.InteriorInspection.FloorMatCount = model.FloorMatCount;
                reception.InteriorInspection.EmergencyKitOk = model.EmergencyKitOk;
                _context.InteriorInspections.Update(reception.InteriorInspection);

                // Subir nuevas fotos de exterior
                string exteriorPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/exterior");
                if (!Directory.Exists(exteriorPath))
                {
                    Directory.CreateDirectory(exteriorPath);
                }
                var newExteriorFiles = new[] { model.ExteriorPhoto1, model.ExteriorPhoto2, model.ExteriorPhoto3 };
                foreach (var file in newExteriorFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                        string filePath = Path.Combine(exteriorPath, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var photo = new Photo
                        {
                            FileName = uniqueFileName,
                            Url = "/uploads/exterior/" + uniqueFileName,
                            Description = "Imagen exterior",
                            ExteriorInspectionId = reception.ExteriorInspection.Id
                        };
                        _context.Photos.Add(photo);
                    }
                }

                // Subir nuevas fotos de interior
                string interiorPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/interior");
                if (!Directory.Exists(interiorPath))
                {
                    Directory.CreateDirectory(interiorPath);
                }
                var newInteriorFiles = new[] { model.InteriorPhoto4, model.InteriorPhoto5, model.InteriorPhoto6 };
                foreach (var file in newInteriorFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                        string filePath = Path.Combine(interiorPath, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var photo = new Photo
                        {
                            FileName = uniqueFileName,
                            Url = "/uploads/interior/" + uniqueFileName,
                            Description = "Imagen interior",
                            InteriorInspectionId = reception.InteriorInspection.Id
                        };
                        _context.Photos.Add(photo);
                    }
                }
                _context.VehicleReceptions.Update(reception);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "La recepción del vehículo se actualizó correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", $"Ocurrió un error al actualizar: {ex.Message}");
            }

            // Recargar listas de selección si hay error
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", model.ClientId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "PlateNumber", model.VehicleId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Buscar la recepción por ID e incluir las inspecciones relacionadas
                var vehicleReception = await _context.VehicleReceptions
                    .Include(vr => vr.ExteriorInspection)
                        .ThenInclude(ei => ei.Photos)
                    .Include(vr => vr.InteriorInspection)
                        .ThenInclude(ii => ii.Photos)
                    .FirstOrDefaultAsync(vr => vr.VehicleReceptionId == id);

                if (vehicleReception == null)
                {
                    TempData["ErrorMessage"] = "No se encontró la recepción de vehículo.";
                    return RedirectToAction("Index");
                }

                // Eliminar fotos de exterior
                if (vehicleReception.ExteriorInspection?.Photos != null)
                {
                    foreach (var photo in vehicleReception.ExteriorInspection.Photos)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photo.Url.TrimStart('/'));
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    _context.Photos.RemoveRange(vehicleReception.ExteriorInspection.Photos);
                }

                // Eliminar fotos de interior
                if (vehicleReception.InteriorInspection?.Photos != null)
                {
                    foreach (var photo in vehicleReception.InteriorInspection.Photos)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photo.Url.TrimStart('/'));
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    _context.Photos.RemoveRange(vehicleReception.InteriorInspection.Photos);
                }

                // Eliminar inspecciones
                if (vehicleReception.ExteriorInspection != null)
                {
                    _context.ExteriorInspections.Remove(vehicleReception.ExteriorInspection);
                }
                if (vehicleReception.InteriorInspection != null)
                {
                    _context.InteriorInspections.Remove(vehicleReception.InteriorInspection);
                }

                // Eliminar la recepción
                _context.VehicleReceptions.Remove(vehicleReception);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["SuccessMessage"] = "Recepción de vehículo eliminada correctamente.";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["ErrorMessage"] = $"Ocurrió un error al eliminar: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExteriorImage(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return Json(new { success = false, message = "Foto no encontrada." });
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Foto eliminada correctamente." });
        }

    }
}
