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

namespace PersonapfihsOntology
{
	[ExcludeFromCodeCoverage]
	public class PriceSpecification : GnossOCBase
	{
		public PriceSpecification() : base() { } 

		public PriceSpecification(SemanticEntityModel pSemCmsModel, LanguageEnum idiomaUsuario) : base()
		{
			mGNOSSID = pSemCmsModel.Entity.Uri;
			mURL = pSemCmsModel.Properties.FirstOrDefault(p => p.PropertyValues.Any(prop => prop.DownloadUrl != null))?.FirstPropertyValue.DownloadUrl;
			this.Schema_validFrom = GetDateValuePropertySemCms(pSemCmsModel.GetPropertyByPath("https://schema.org/validFrom"));
			this.Schema_price = GetNumberIntPropertyValueSemCms(pSemCmsModel.GetPropertyByPath("https://schema.org/price"));
			this.Eschema_identifier = GetPropertyValueSemCms(pSemCmsModel.GetPropertyByPath("https://schema.org/extended/identifier"));
		}

		public virtual string RdfType { get { return "https://schema.org/PriceSpecification"; } }
		public virtual string RdfsLabel { get { return "https://schema.org/PriceSpecification"; } }
		public OntologyEntity Entity { get; set; }

		[LABEL(LanguageEnum.es,"Fecha del Valor")]
		[LABEL(LanguageEnum.en,"Valuation dated")]
		[RDFProperty("https://schema.org/validFrom")]
		public  DateTime? Schema_validFrom { get; set;}

		[LABEL(LanguageEnum.es,"Valor")]
		[LABEL(LanguageEnum.en,"Value")]
		[RDFProperty("https://schema.org/price")]
		public  int? Schema_price { get; set;}

		[LABEL(LanguageEnum.es,"ID")]
		[RDFProperty("https://schema.org/extended/identifier")]
		public  string Eschema_identifier { get; set;}


		internal override void GetProperties()
		{
			base.GetProperties();
			if (this.Schema_validFrom.HasValue){
				propList.Add(new DateOntologyProperty("schema:validFrom", this.Schema_validFrom.Value));
				}
			propList.Add(new StringOntologyProperty("schema:price", this.Schema_price.ToString()));
			propList.Add(new StringOntologyProperty("eschema:identifier", this.Eschema_identifier));
		}

		internal override void GetEntities()
		{
			base.GetEntities();
		} 











	}
}
