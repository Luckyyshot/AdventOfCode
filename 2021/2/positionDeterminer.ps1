Function swimmerFinalPosition{
	[string[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	$position = 0
	$depth = 0
	Foreach($pair in $inputdata){
		if($pair.split(' ')[0] -eq 'forward'){
			$position += [int]$pair.split(' ')[1]
		}
		if($pair.split(' ')[0] -eq 'down'){
			$depth += [int]$pair.split(' ')[1]
		}
		if($pair.split(' ')[0] -eq 'up'){
			$depth -= [int]$pair.split(' ')[1]
		}
	}
	"Final position: " + $position + " Final depth: " + $depth
	"Final calculated number: " + ($position * $depth)
}

Function swimmerFinalPositionAim{
	[string[]]$inputdata = Get-Content "$PSScriptRoot\input.txt"
	$position = 0
	$aim = 0
	$depth = 0
	Foreach($pair in $inputdata){
		if($pair.split(' ')[0] -eq 'forward'){
			$position += [int]$pair.split(' ')[1]
			$depth += [int]$pair.split(' ')[1] * $aim
		}
		if($pair.split(' ')[0] -eq 'down'){
			$aim += [int]$pair.split(' ')[1]
		}
		if($pair.split(' ')[0] -eq 'up'){
			$aim -= [int]$pair.split(' ')[1]
		}
	}
	"Final position: " + $position + " Final depth: " + $depth
	"Final calculated number: " + ($position * $depth)
}

swimmerFinalPosition
swimmerFinalPositionAim