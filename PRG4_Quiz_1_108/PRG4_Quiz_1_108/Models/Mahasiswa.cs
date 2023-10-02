using System.ComponentModel.DataAnnotations;

namespace PRG4_Quiz_1_108.Models
{
    public class Mahasiswa
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama maksimal 30 karakter.")]

        public string nama { get; set; }

        [Required(ErrorMessage = "Prodi wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Prodi maksimal 30 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Prodi hanya boleh berisi huruf.")]

        public string prodi { get; set; }

        public int angkatan { get; set; }
    }
}
