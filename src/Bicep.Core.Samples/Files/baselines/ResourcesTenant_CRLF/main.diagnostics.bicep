targetScope = 'tenant'

var managementGroups = [
  {
    name: 'one'
    displayName: 'The first'
  }
  {
    name: 'two'
    displayName: 'The second'
  }
]

resource singleGroup 'Microsoft.Management/managementGroups@2020-05-01' = {
  name: 'myMG'
  properties: {
    displayName: 'This one is mine!'
  }
}

resource manyGroups 'Microsoft.Management/managementGroups@2020-05-01' = [for mg in managementGroups: {
  name: mg.name
  properties: {
    displayName: '${mg.displayName} (${singleGroup.properties.displayName})'
  }
}]

resource anotherSet 'Microsoft.Management/managementGroups@2020-05-01' = [for (mg, index) in managementGroups: {
  name: concat(mg.name, '-one-', index)
//@[08:39) [prefer-interpolation (Warning)] Use string interpolation instead of the concat function. (bicep core linter https://aka.ms/bicep/linter-diagnostics#prefer-interpolation) |concat(mg.name, '-one-', index)|
  properties: {
    displayName: '${mg.displayName} (${singleGroup.properties.displayName}) (set 1) (index ${index})'
  }
  dependsOn: [
    manyGroups
  ]
}]

resource yetAnotherSet 'Microsoft.Management/managementGroups@2020-05-01' = [for mg in managementGroups: {
  name: concat(mg.name, '-two')
//@[08:31) [prefer-interpolation (Warning)] Use string interpolation instead of the concat function. (bicep core linter https://aka.ms/bicep/linter-diagnostics#prefer-interpolation) |concat(mg.name, '-two')|
  properties: {
    displayName: '${mg.displayName} (${singleGroup.properties.displayName}) (set 2)'
  }
  dependsOn: [
    anotherSet[0]
  ]
}]

output managementGroupIds array = [for i in range(0, length(managementGroups)): {
//@[26:31) [use-user-defined-types (Warning)] Use user-defined types instead of 'object' or 'array'. (bicep core linter https://aka.ms/bicep/linter-diagnostics#use-user-defined-types) |array|
  name: yetAnotherSet[i].name
  displayName: yetAnotherSet[i].properties.displayName
}]

