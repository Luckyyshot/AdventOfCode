Function EpsilonGamma{
	[string[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	[int32[]]$result = ,0 * $inputdata[0].Length
	Foreach($string in $inputdata){
		for($i = 0;$i -lt $result.Length;$i++){
			$result[$i] += [System.Int32]::Parse($string[$i])
		}
	}
	for($i = 0;$i -lt $result.Length;$i++){
		if($result[$i] -gt ($inputdata.Length/2)){
			$result[$i] = 1
		}
		else{
			$result[$i] = 0
		}
	}
	$gammarate = ([string]$result).replace(" ", "")
	
	$epsilonrate = $result
	for($i = 0;$i -lt $epsilonrate.Length;$i++){
		if($epsilonrate[$i] -eq 1){
			$epsilonrate[$i] = 0
		}
		else{
			$epsilonrate[$i] = 1
		}
	}
	$epsilonrate = ([string]$epsilonrate).replace(" ", "")
	
	"Epsilon rate: " + [Convert]::ToInt32($epsilonrate,2) + " Gamma rate: " + [Convert]::ToInt32($gammarate,2)
	"Final result (power consumption): " + [Convert]::ToInt32($epsilonrate,2) * [Convert]::ToInt32($gammarate,2)
	
	
}

Function OxygenCO2{
	[string[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	
	[System.Collections.ArrayList]$oxygen = $inputdata
	for($i = 0;$i -lt $oxygen[0].Length;$i++){
		$bitcount = 0
		foreach($string in $oxygen){
			$bitcount += [System.Int32]::Parse($string[$i])
		}
		
		if($bitcount -ge ($oxygen.Count/2)){
			$oxygen.Clone() | Foreach-Object{
				if($_[$i] -ne "1") {
					$oxygen.Remove($_)
				}
			}
		}
		else{
			$oxygen.Clone() | Foreach-Object{
				if($_[$i] -ne "0") {
					$oxygen.Remove($_)
				}
			}
		}
		if($oxygen.Count -eq 1) {break}
	}
	
	[System.Collections.ArrayList]$CO2 = $inputdata
	for($i = 0;$i -lt $CO2[0].Length;$i++){
		$bitcount = 0
		foreach($string in $CO2){
			$bitcount += [System.Int32]::Parse($string[$i])
		}
		
		if($bitcount -ge ($CO2.Count/2)){
			$CO2.Clone() | Foreach-Object{
				if($_[$i] -ne "0") {
					$CO2.Remove($_)
				}
			}
		}
		else{
			$CO2.Clone() | Foreach-Object{
				if($_[$i] -ne "1") {
					$CO2.Remove($_)
				}
			}
		}
		if($CO2.Count -eq 1) {break}
	}
	
	"Oxygen rate: " + [Convert]::ToInt32($oxygen,2) + " CO2 rate: " + [Convert]::ToInt32($CO2,2)
	"Final result (life support): " + [Convert]::ToInt32($oxygen,2) * [Convert]::ToInt32($CO2,2)
}

EpsilonGamma
OxygenCO2























