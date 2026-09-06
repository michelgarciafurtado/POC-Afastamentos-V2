using System.Text.Json.Serialization;

namespace POC_Afastamentos_V2.core.domain.valueobjects;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(DetalhesDispensaRecompensa), typeDiscriminator: "DispensaRecompensa")]
[JsonDerivedType(typeof(DetalhesDispensaServico), typeDiscriminator: "DispensaServico")]
[JsonDerivedType(typeof(DetalhesLicencaPremio), typeDiscriminator: "LicencaPremio")]
[JsonDerivedType(typeof(DetalhesLicPaterGest), typeDiscriminator: "LicPaterGest")]
[JsonDerivedType(typeof(DetalhesLuto), typeDiscriminator: "Luto")]
[JsonDerivedType(typeof(DetalhesNupcias), typeDiscriminator: "Nupcias")]
[JsonDerivedType(typeof(DetalhesFeriasSobrestadas), typeDiscriminator: "FeriasSobrestadas")]
[JsonDerivedType(typeof(DetalhesLicencaPremioSobrestada), typeDiscriminator: "LicencaPremioSobrestada")]
[JsonDerivedType(typeof(DetalhesTransito), typeDiscriminator: "Transito")]
public abstract record DetalhesAfastamento;

