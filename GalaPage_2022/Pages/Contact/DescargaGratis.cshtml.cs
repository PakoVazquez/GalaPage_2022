using GalaPage_2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace GalaPage_2022.Pages.Contact
{
    public class DescargaGratisModel : PageModel
    {
        [BindProperty]
        public ContactoModel Contacto { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            try
            {
                SmtpClient client = new("mail.noip.com");
                MailAddress from = new("cortesrestaurante@galasistemas.com", "Gala Sistemas", System.Text.Encoding.UTF8);
                MailAddress to = new("anaveronica@galasistemas.com");
                MailMessage message = new(from, to);
                message.Subject = "Cliente";
                message.Body = $"<h2>Cliente: {Contacto.Nombre}, Correo: {Contacto.Correo}, Teléfono: {Contacto.Telefono}</h2>" +
                    $"<p>Negocio: {Contacto.NombreDelNegocio}.</p>" +
                    $"<p>Cliente para Instalación Inmediata</p>";
                message.IsBodyHtml = true;

                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Host = "mail.noip.com";
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cortesrestaurante@galasistemas.com", "Ccigacama01*");

                client.Send(message);
                client.Dispose();

                return RedirectToPage("/Contact/ThankyouPage", new { Contacto.Nombre });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
