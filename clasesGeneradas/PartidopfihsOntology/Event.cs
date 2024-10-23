using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Gnoss.ApiWrapper;
using Gnoss.ApiWrapper.Model;
using Gnoss.ApiWrapper.Helpers;
using GnossBase;
using Es.Riam.Gnoss.Web.MVC.Models;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using Gnoss.ApiWrapper.Exceptions;
using System.Diagnostics.CodeAnalysis;
using Person = PersonapfihsOntology.Person;
using Thing = TipopfihsOntology.Thing;

namespace PartidopfihsOntology
{
	[ExcludeFromCodeCoverage]
	public class Event : GnossOCBase
	{
		public Event() : base() { } 

		public Event(SemanticEntityModel pSemCmsModel, LanguageEnum idiomaUsuario) : base()
		{
			mGNOSSID = pSemCmsModel.Entity.Uri;
			mURL = pSemCmsModel.Properties.FirstOrDefault(p => p.PropertyValues.Any(prop => prop.DownloadUrl != null))?.FirstPropertyValue.DownloadUrl;
			SemanticPropertyModel propSchema_actor = pSemCmsModel.GetPropertyByPath("https://schema.org/actor");
			if (propSchema_actor != null && propSchema_actor.PropertyValues.Count > 0 && propSchema_actor.PropertyValues[0].RelatedEntity != null)
			{
				Schema_actor = new Person(propSchema_actor.PropertyValues[0].RelatedEntity,idiomaUsuario);
			}
			SemanticPropertyModel propSchema_about = pSemCmsModel.GetPropertyByPath("https://schema.org/about");
			if (propSchema_about != null && propSchema_about.PropertyValues.Count > 0 && propSchema_about.PropertyValues[0].RelatedEntity != null)
			{
				Schema_about = new Thing(propSchema_about.PropertyValues[0].RelatedEntity,idiomaUsuario);
			}
			this.Eschema_identifierevento = GetPropertyValueSemCms(pSemCmsModel.GetPropertyByPath("https://schema.org/extended/identifierevento"));
			this.Eschema_Minute = GetNumberIntPropertyValueSemCms(pSemCmsModel.GetPropertyByPath("https://schema.org/extended/Minute"));
		}

		public virtual string RdfType { get { return "https://schema.org/Event"; } }
		public virtual string RdfsLabel { get { return "https://schema.org/Event"; } }
		public OntologyEntity Entity { get; set; }

		[LABEL(LanguageEnum.es,"Jugador Involucrado")]
		[LABEL(LanguageEnum.en,"Player Involved")]
		[RDFProperty("https://schema.org/actor")]
		public  Person Schema_actor  { get; set;} 
		public string IdSchema_actor  { get; set;} 

		[LABEL(LanguageEnum.en,"Type")]
		[LABEL(LanguageEnum.es,"Tipo")]
		[RDFProperty("https://schema.org/about")]
		public  Thing Schema_about  { get; set;} 
		public string IdSchema_about  { get; set;} 

		[LABEL(LanguageEnum.es,"https://schema.org/extended/identifierevento")]
		[RDFProperty("https://schema.org/extended/identifierevento")]
		public  string Eschema_identifierevento { get; set;}

		[LABEL(LanguageEnum.es,"min.")]
		[RDFProperty("https://schema.org/extended/Minute")]
		public  int? Eschema_Minute { get; set;}


		internal override void GetProperties()
		{
			base.GetProperties();
			propList.Add(new StringOntologyProperty("schema:actor", this.IdSchema_actor));
			propList.Add(new StringOntologyProperty("schema:about", this.IdSchema_about));
			propList.Add(new StringOntologyProperty("eschema:identifierevento", this.Eschema_identifierevento));
			propList.Add(new StringOntologyProperty("eschema:Minute", this.Eschema_Minute.ToString()));
		}

		internal override void GetEntities()
		{
			base.GetEntities();
		} 











	}
}
