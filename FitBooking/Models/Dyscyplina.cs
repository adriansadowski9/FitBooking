//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public partial class Dyscyplina
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Dyscyplina()
    {
        this.Lista_dyscyplin = new HashSet<Lista_dyscyplin>();
    }

    public int Id { get; set; }
    [Required(ErrorMessage = "Proszę wprowadzić nazwę dyscypliny")]
    [RegularExpression(@"^[A-Za-ząćęłńóśźżĄĘŁŃÓŚŹŻ]+[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ.''-'\s]*$", ErrorMessage = "Błąd, wyrażenie powinno składać się tylko z liter")]
    public string nazwa { get; set; }
    [Required(ErrorMessage = "Proszę wprowadzić opis")]
    [RegularExpression(@"^[A-Za-ząćęłńóśźżĄĘŁŃÓŚŹŻ]+[0-9a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ.''-'\s]*$", ErrorMessage = "Błąd, wyrażenie powinno składać się tylko z liter i cyfr")]
    public string opis { get; set; }
    public bool IsChecked { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Lista_dyscyplin> Lista_dyscyplin { get; set; }
}