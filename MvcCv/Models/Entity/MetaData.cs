using System;
using System.ComponentModel.DataAnnotations;

namespace MvcCv.Models.Entity
{
    [MetadataType(typeof(AdminMeta))]
    public partial class TblAdmin { }

    public class AdminMeta
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        [StringLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [StringLength(50)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }

    [MetadataType(typeof(DeneyimMeta))]
    public partial class TblDeneyimlerim { }

    public class DeneyimMeta
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(100)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [StringLength(100)]
        [Display(Name = "Alt Başlık")]
        public string AltBaslik { get; set; }

        [StringLength(500)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [StringLength(30)]
        [Display(Name = "Tarih")]
        public string Tarih { get; set; }

        [StringLength(250)]
        [Display(Name = "Logo URL")]
        public string Logo { get; set; }
    }

    [MetadataType(typeof(EgitimMeta))]
    public partial class TblEgitimlerim { }

    public class EgitimMeta
    {
        [Required(ErrorMessage = "Başlık girilmelidir.")]
        [StringLength(100)]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [StringLength(100)]
        [Display(Name = "Alt Başlık 1")]
        public string Altbaslik1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Alt Başlık 2")]
        public string AltBaslik2 { get; set; }

        [StringLength(10)]
        [Display(Name = "GNO")]
        public string GNO { get; set; }

        [StringLength(30)]
        [Display(Name = "Tarih")]
        public string Tarih { get; set; }
    }

    [MetadataType(typeof(HakkimdaMeta))]
    public partial class TblHakkimda { }

    public class HakkimdaMeta
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50)]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [StringLength(250)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [Display(Name = "E-posta")]
        public string Mail { get; set; }

        [StringLength(250)]
        [Display(Name = "Profil Resmi")]
        public string Resim { get; set; }

        [StringLength(1000)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }

    [MetadataType(typeof(HobiMeta))]
    public partial class TblHobilerim { }

    public class HobiMeta
    {
        [StringLength(500)]
        [Display(Name = "Açıklama 1")]
        public string Aciklama1 { get; set; }

        [StringLength(500)]
        [Display(Name = "Açıklama 2")]
        public string Aciklama2 { get; set; }
    }

    [MetadataType(typeof(IletisimMeta))]
    public partial class Tbliletisim { }

    public class IletisimMeta
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        [StringLength(100)]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Mail adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        [StringLength(100)]
        [Display(Name = "E-posta")]
        public string Mail { get; set; }

        [StringLength(150)]
        [Display(Name = "Konu")]
        public string Konu { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz.")]
        [StringLength(1000)]
        [Display(Name = "Mesaj")]
        public string Mesaj { get; set; }

        [Display(Name = "Tarih")]
        public DateTime? Tarih { get; set; }
    }

    [MetadataType(typeof(OzellikMeta))]
    public partial class TblOzelliklerim { }

    public class OzellikMeta
    {
        [Required(ErrorMessage = "Yetenek alanı zorunludur.")]
        [StringLength(100)]
        [Display(Name = "Yetenek")]
        public string Yetenek { get; set; }

        [StringLength(10)]
        [Display(Name = "Oran")]
        public string Oran { get; set; }
    }

    [MetadataType(typeof(SertifikaMeta))]
    public partial class TblSertifikalarım { }

    public class SertifikaMeta
    {
        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(300)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
