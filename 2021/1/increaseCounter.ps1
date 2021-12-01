Function getIncreaseLastNumber{
	[int32[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	$increaseCounter = 0
	for($i=1;$i -lt $inputdata.Length; $i++){
		if($inputdata[$i-1] -lt $inputdata[$i]){
			$increaseCounter++
		}
		$temp = $inputdata[$i]
	}
	"Count of simple increases: " + $increaseCounter
}

Function getIncrease3NumberMovingSum{
	[int32[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	$increaseCounter = 0
	$tempSum = $inputdata[0] + $inputdata[1] + $inputdata[2]
	for($i=1;$i -lt $inputdata.Length - 2; $i++){
		$sum = $inputdata[$i] + $inputdata[$i+1] + $inputdata[$i+2]
		if($tempSum -lt $sum){
			$increaseCounter++
		}
		$tempSum = $sum
	}
	"Count of moving sum increases: " + $increaseCounter
}

getIncreaseLastNumber
getIncrease3NumberMovingSum