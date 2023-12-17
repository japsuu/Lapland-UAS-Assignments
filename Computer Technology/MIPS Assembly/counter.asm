
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