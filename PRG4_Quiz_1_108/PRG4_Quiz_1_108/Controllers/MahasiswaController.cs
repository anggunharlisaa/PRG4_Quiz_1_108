using Microsoft.AspNetCore.Mvc;
using PRG4_Quiz_1_108.Models;

namespace PRG4_Quiz_1_108.Controllers
{
    public class mahasiswaController : Controller
    {
        private static List<Mahasiswa> mahasiswas = InitializeData();

        private static List<Mahasiswa> InitializeData()
        {
            List<Mahasiswa> initialData = new List<Mahasiswa>
            {
                new Mahasiswa
                {
                    id = 1,
                    nama = "Fattah",
                    prodi = "Teknik Informatika",
                    angkatan = 2020
                },
                new Mahasiswa
                {
                    id = 2,
                    nama = "Shafira",
                    prodi = "Teknik Industri",
                    angkatan = 2020
                }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Mahasiswa> mahasiswaList = mahasiswas.ToList();
            return View(mahasiswaList);
        }

        public IActionResult form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult form(Mahasiswa Mahasiswa)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (mahasiswas.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                Mahasiswa.id = new_id;

                mahasiswas.Add(Mahasiswa);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }
            return View(Mahasiswa);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus mahasiswa." };
            try
            {
                var Mahasiswa = mahasiswas.FirstOrDefault(b => b.id == id);
                if (Mahasiswa != null)
                {
                    mahasiswas.Remove(Mahasiswa);
                    response = new { success = true, message = "Mahasiswa berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Mahasiswa tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }
            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Mahasiswa Mahasiswa = mahasiswas.FirstOrDefault(a => a.id == id);

            if (Mahasiswa == null)
            {
                return NotFound();
            }

            return View(Mahasiswa);
        }

        [HttpPost]

        public IActionResult Edit(Mahasiswa Mahasiswa)
        {
            if (ModelState.IsValid)
            {
                Mahasiswa newMahasiswa = mahasiswas.FirstOrDefault(a => a.id == Mahasiswa.id);
                if (newMahasiswa == null)
                {
                    return NotFound();
                }
                newMahasiswa.nama = Mahasiswa.nama;
                newMahasiswa.prodi = Mahasiswa.prodi;
                newMahasiswa.angkatan = Mahasiswa.angkatan;


                TempData["SuccessMessage"] = "Mahasiswa berhasil diupdate.";
                return RedirectToAction("Index");
            }
            return View(Mahasiswa);
        }
    }
}
