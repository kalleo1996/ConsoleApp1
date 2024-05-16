using ConsoleApp1;
using HandlebarsDotNet;
using HandlebarsDotNet.Compiler.Resolvers;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
//Example 1
//with fhir resource data passing as data to template
var bundle = new Bundle
{
    Type = Bundle.BundleType.Collection
};

// Create the first entry
var entry1 = new Bundle.EntryComponent
{
    FullUrl = "fullurl1",
    Resource = new Observation
    {
        Id = "observation1",
        Code = new CodeableConcept("http://loinc.org", "12345", "Some observation")
    }
};

// Create the second entry
var entry2 = new Bundle.EntryComponent
{
    FullUrl = "fullurl2",
    Resource = new Observation
    {
        Id = "observation2",
        Code = new CodeableConcept("http://loinc.org", "67890", "Another observation")
    }
};

// Add the entries to the bundle
bundle.Entry.Add(entry1);
bundle.Entry.Add(entry2);

Hl7.Fhir.Model.Resource rs = bundle;
// Render the template with the bundle

var datax = new
{
    resource = rs
};

// here  having UpperCamelCaseExpressionNameResolver 
HandlebarsConfiguration s_configuration = new HandlebarsConfiguration { ExpressionNameResolver = new UpperCamelCaseExpressionNameResolver() };
//without having UpperCamelCaseExpressionNameResolver
//uncomment  the below  code  and check the behaviour without the UpperCamelCaseExpressionNameResolver
//HandlebarsConfiguration s_configuration = new HandlebarsConfiguration {  };
IHandlebars s_handlebars = Handlebars.Create(s_configuration);
var template = File.ReadAllText(@"./Textfiles/Composition-template.hbs");
var compiledTemplate = s_handlebars.Compile(template);
string templateOutput = compiledTemplate(datax);
//here with UpperCamelCaseExpressionNameResolver you will not get <content> under {{#each resource.entry}} but without UpperCamelCaseExpressionNameResolver u will get it .

Console.WriteLine(templateOutput);

//Example 2
//without using fhir model same kind of exercise , its working fine without any issue 

var template2 = @"
{{#each resource.Entries}}
Patient:
- ID: {{Patient.Id}}
- Name: {{Patient.Name}}
- Gender: {{Patient.Gender}}
- Date of Birth: {{Patient.DateOfbirth}}
- Address: {{Patient.Address}}
- Phone: {{Patient.PhoNe}}
- Email: {{Patient.email}}
{{/each}}";


// Create Handlebars instance



Bundlex bundlex2 = new Bundlex();

// Creating patient entries
Entry entry1x = new Entry
{
    Patient = new Patientx
    {
        Id = "P001",
        Name = "John Doe",
        Gender = "Male",
        DateOfBirth = "1990-01-15",
        Address = "123 Main St, City, Country",
        Phone = "+1234567890",
        Email = "john.doe@example.com"
    }
};

Entry entry2x = new Entry
{
    Patient = new Patientx
    {
        Id = "P002",
        Name = "Jane Smith",
        Gender = "Female",
        DateOfBirth = "1985-06-20",
        Address = "456 Elm St, City, Country",
        Phone = "+9876543210",
        Email = "jane.smith@example.com"
    }
};

// Adding entries to the bundlex
bundlex2.Entries.Add(entry1x);
bundlex2.Entries.Add(entry2x);


var s_handlebars2 = Handlebars.Create(s_configuration);

// Compile the Handlebars template
var compiledTemplate2 = s_handlebars2.Compile(template2);

var dataNormalModelwithoutFHIR = new
{
    resource = bundlex2
};
// Apply the template to the data
string templateOutput2 = compiledTemplate2(dataNormalModelwithoutFHIR);
Console.WriteLine(templateOutput2);

