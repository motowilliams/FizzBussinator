properties {

  #PARAMS
  $version = "1.0.0.0"
  $build_level = "Debug"
  $build_number = "build_number_not_set"
  $commit_hash = "hash_not_set"
  $nuget_config_path = ""
  $gitpath = ""

  #PATHS
  $build_dir = Split-Path $psake.build_script_file
  $solution_dir = Split-Path $build_dir
  $build_output = "$build_dir\artifacts"
  $srcDir = "$solution_dir\src"
  $nuget_dir = "$build_dir\..\src\packages\"
  $package_dir = "$build_dir\..\packages"
  $artifacts_dir = "$build_dir\..\artifacts"
  $tests_dir = "$build_dir\..\tests"
 
  #SLN INFO
  $company_name = "AcmeCompany"
  $solution_name = "AcmeCompany.FizzBuzzinator"
  $solution_file = "$srcDir\$solution_name.sln"
  $client_apps = @("AcmeCompany.FizzBuzzinator.Console")
  $tests = "AcmeCompany.FizzBuzzinator.Tests"
}

include tools\psake_utils.ps1
include tools\xunit.ps1
include tools\config-utils.ps1
include tools\nuget-utils.ps1
include tools\git-utils.ps1

TaskSetup {
  $script:GitPath = $gitpath
}

task default -depends Compile, Run-Dotnet-Tests, Copy-Artifacts, Get-ReleaseNotes, Get-Version

task Run-Dotnet-Tests -precondition { $tests -ne $null }  -depends Compile {

  $xunitPath = "$package_dir\xunit.runner.console.2.0.0\tools\xunit.console.exe"
  $testAssembly = "$srcDir\$tests\bin\$build_level\$tests.dll" 
  
  Write-Host $xunitPath $testAssembly
  & $xunitPath $testAssembly
}

task Compile -depends Clean, Package-Restore {
  $script:build_level = $build_level
  Exec {
  	msbuild "$solution_file" `
  	        /m /nr:false `
  	        /t:Rebuild /nologo /v:m `
  	        /p:Configuration="$script:build_level" `
  	        /p:Platform="Any CPU" /p:TrackFileAccess=false
  }
}

task Clean {
  foreach($assembly in $assemblies + $client_apps + $web_apps + $tests){
    $bin = "$srcDir\$assembly\bin\"
    $obj = "$srcDir\$assembly\obj\"
    Write-Host "Removing $bin"
    Delete-Directory($bin)
    Write-Host "Removing $obj"
    Delete-Directory($obj)
  }
}

task Copy-Artifacts {
  Copy-Item -Recurse -Force $srcDir\$client_apps\bin\$build_level\ $artifacts_dir\$client_apps
}