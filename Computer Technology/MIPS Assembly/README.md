
# MIPS Assembly Assignments

## Tehtävä 1 - Counter

### Tehtävänanto

Kirjoita MARS-ohjelmaa käyttäen MIPS-assemblyllä ohjelma, joka
- laskee luvut 1-10 yhteen (mukaan lukien sekä 1 että 10)
- tulostaa lopullisen tuloksen ruudulle
- Sisältää tarvittavat alustukset ja lopetukset datalle.

### Ratkaisu

```mips
# Assignment:
# Write a program with MIPS-assembly, that:
# - sums the numbers 1-10 (including 1 and 10)
# - prints the result
# - contains the necessary data initializations and deinitializations

    .data
    .text
    .globl main

main:
    li $t0, 0              	# Initialize loop counter to 0 (save 0 to the register t0)
    li $t1, 10             	# Set the upper limit of the loop (save 10 to the register t1)
    li $t2, 0              	# Initialize the result to 0 (save 0 to the register t2)

    
    loop:			# Loop to calculate the sum
        addi $t0, $t0, 1    	# Increment the loop counter (number of iterations we've completed)
        add $t2, $t2, $t0   	# Add the current value to the result
        bne $t0, $t1, loop  	# Continue loop if counter is not equal to the upper limit

    li $v0, 1             	# Set v0 register to signal syscall to print an integer
    move $a0, $t2		# Write the result register value to the argument register, to be used by the syscall
    syscall			# Print the result

    li $v0, 10             	# Set v0 register to system exit call code
    syscall			# Exit

    .end main
```

## Tehtävä 2 - Fibonacci

### Tehtävänanto

Kirjoita MIPS-assemblyllä ohjelma, joka laskee ja tulostaa Fibonaccin lukusarjan 11
ensimmäistä numeroa
- Fibonaccin lukujono muodostetaan siten, että lasketaan yhteen aina 2 edellistä
lukua.
- 11 ensimmäistä lukua olisivat siis: `0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55`

### Ratkaisu

```mips
# Assignment:
# Write a program with MIPS-assembly, that:
# - calculates the 11 first numbers of the Fibonacci sequence
# - prints the result

    .data
    	separator:  .asciiz ", "	# Store the text we will use to separate the digits
    .text
    .globl main

main:
    li $t0, 0		# Initialize the loop counter to 0
    li $t1, 11		# Set the upper limit of the loop (11)
    			# We need to keep track of the two latest numbers in the sequence, to be able to claculate the next one:
    li $t2, 1           # Initialize the first number to 1 (save 1 to the register t2)
    li $t3, 0           # Initialize the second number to 0 (save 0 to the register t3)

    loop:
    	# Print the current sequence member (t3)
    	jal printmember
    	
    	# Calculate the next sequence member
    	add $t4, $t2, $t3	# Set t4 to the sum of t2 and t3. t4 is now the next number in the sequence
    	
    	# Drop the "oldest" member of the sequence (t2), and move the two latest into t2 and t3
    	move $t2, $t3		# Set t2 to t3
    	move $t3, $t4		# Set t3 to t4. Now the value in t3 is the "latest" calculated sequence member, while t2 is the previous "latest" member
    	
        addi $t0, $t0, 1    	# Increment the loop counter (number of iterations we've completed)
        blt $t0, $t1, addsep  	# If there are more numbers to print (if the loop counter is not equal to the upper limit), add a separator
        
    	li $v0, 10          	# Set v0 register to system exit call code
    	syscall			# Exit gracefully :)

    printmember:	# Subroutine to print the latest sequence member in t3
    	li $v0, 1		# Signal the syscall to print an integer
	move $a0, $t3		# Write t3 to the argument register, to be used by the syscall
	syscall			# Print the result
    	jr $ra			# Jump-return back to the main loop

    addsep:		# Subroutine to print the separator text
    	li $v0, 4		# Signal the syscall that we want to print a string
    	la $a0, separator	# Write the separator text to the argument register
    	syscall			# Print the separator
    	j loop			# Jump back to the main loop

    .end main
```
