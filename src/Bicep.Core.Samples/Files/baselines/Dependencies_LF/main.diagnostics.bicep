param deployTimeParam string = 'steve'
var deployTimeVar = 'nigel'
var dependentVar = {
  dependencies: [
    deployTimeVar
    deployTimeParam
  ]
}

var resourceDependency = {
  dependenciesA: [
    resA.id
    resA.name
    resA.type
    resA.properties.deployTime
    resA.properties.eTag
  ]
}

output resourceAType string = resA.type
resource resA 'My.Rp/myResourceType@2020-01-01' = {
//@[14:47) [BCP081 (Warning)] Resource type "My.Rp/myResourceType@2020-01-01" does not have types available. Bicep is unable to validate resource properties prior to deployment, but this will not block the resource from being deployed. (bicep https://aka.ms/bicep/core-diagnostics#BCP081) |'My.Rp/myResourceType@2020-01-01'|
  name: 'resA'
  properties: {
    deployTime: dependentVar
    eTag: '1234'
  }
}

output resourceBId string = resB.id
resource resB 'My.Rp/myResourceType@2020-01-01' = {
//@[14:47) [BCP081 (Warning)] Resource type "My.Rp/myResourceType@2020-01-01" does not have types available. Bicep is unable to validate resource properties prior to deployment, but this will not block the resource from being deployed. (bicep https://aka.ms/bicep/core-diagnostics#BCP081) |'My.Rp/myResourceType@2020-01-01'|
  name: 'resB'
  properties: {
    dependencies: resourceDependency
  }
}

var resourceIds = {
  a: resA.id
  b: resB.id
}

resource resC 'My.Rp/myResourceType@2020-01-01' = {
//@[14:47) [BCP081 (Warning)] Resource type "My.Rp/myResourceType@2020-01-01" does not have types available. Bicep is unable to validate resource properties prior to deployment, but this will not block the resource from being deployed. (bicep https://aka.ms/bicep/core-diagnostics#BCP081) |'My.Rp/myResourceType@2020-01-01'|
  name: 'resC'
  properties: {
    resourceIds: resourceIds
  }
}

resource resD 'My.Rp/myResourceType/childType@2020-01-01' = {
//@[14:57) [BCP081 (Warning)] Resource type "My.Rp/myResourceType/childType@2020-01-01" does not have types available. Bicep is unable to validate resource properties prior to deployment, but this will not block the resource from being deployed. (bicep https://aka.ms/bicep/core-diagnostics#BCP081) |'My.Rp/myResourceType/childType@2020-01-01'|
  name: '${resC.name}/resD'
//@[08:27) [use-parent-property (Warning)] Resource "resD" has its name formatted as a child of resource "resC". The syntax can be simplified by using the parent property. (bicep core linter https://aka.ms/bicep/linter-diagnostics#use-parent-property) |'${resC.name}/resD'|
  properties: {
  }
}

resource resE 'My.Rp/myResourceType/childType@2020-01-01' = {
//@[14:57) [BCP081 (Warning)] Resource type "My.Rp/myResourceType/childType@2020-01-01" does not have types available. Bicep is unable to validate resource properties prior to deployment, but this will not block the resource from being deployed. (bicep https://aka.ms/bicep/core-diagnostics#BCP081) |'My.Rp/myResourceType/childType@2020-01-01'|
  name: 'resC/resD_2'
//@[08:21) [use-parent-property (Warning)] Resource "resE" has its name formatted as a child of resource "resC". The syntax can be simplified by using the parent property. (bicep core linter https://aka.ms/bicep/linter-diagnostics#use-parent-property) |'resC/resD_2'|
  properties: {
    resDRef: resD.id
  }
}

output resourceCProperties object = resC.properties
//@[27:33) [use-user-defined-types (Warning)] Use user-defined types instead of 'object' or 'array'. (bicep core linter https://aka.ms/bicep/linter-diagnostics#use-user-defined-types) |object|

