using FitBooking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public partial class Uzytkownik
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Uzytkownik()
    {
        this.Adres = new HashSet<Adres>();
        this.Lista_spotkan = new HashSet<Lista_spotkan>();
        this.Lista_spotkan1 = new HashSet<Lista_spotkan>();
        this.Spolecznosc = new HashSet<Spolecznosc>();
        this.Info = new HashSet<Info>();
    }

    public int Id { get; set; }
    [Required(ErrorMessage = "Proszê wprowadziæ imiê")]
    [MinLength(2, ErrorMessage = "Imie powinno miec wiecej niz dwa znaki")]
    public string imie { get; set; }
    [Required(ErrorMessage = "Proszê wprowadziæ nazwisko")]
    public string nazwisko { get; set; }
    [Required(ErrorMessage = "Proszê wybraæ datê urodzenia")]
    [DisplayName("data urodzenia")]
    public string data_urodzenia { get; set; }
   // [Required(ErrorMessage = "Proszê wprowadziæ e-mail")]
    //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Nieprawid³owy format email")]
    public string email { get; set; }
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^([0-9]{9})|(([0-9]{3}-){2}[0-9]{3})$", ErrorMessage = "B³¹d, numer telefonu powinien sk³adaæ siê tylko z cyfr")]

    public string telefon { get; set; }
    public string id_aspUser { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Adres> Adres { get; set; }
    public virtual AspNetUsers AspNetUsers { get; set; }
     [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Lista_spotkan> Lista_spotkan { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Lista_spotkan> Lista_spotkan1 { get; set; }
    public virtual ICollection<Spolecznosc> Spolecznosc { get; set; }
    public virtual ICollection<Info> Info{ get; set; }
}