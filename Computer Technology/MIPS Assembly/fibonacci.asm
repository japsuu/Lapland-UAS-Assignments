
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
    li $t2, 0           # Initialize the first number to 0 (save 0 to the register t2)
    li $t3, 1           # Initialize the second number to 1 (save 1 to the register t3)

    loop:
    	# Calculate the next sequence member
    	add $t4, $t2, $t3	# Set t4 to the sum of t2 and t3. t4 is now the next number in the sequence
    	
    	# Drop the "oldest" member of the sequence (t2), and move the two latest into t2 and t3
    	move $t2, $t3		# Set t2 to t3
    	move $t3, $t4		# Set t3 to t4. Now the value in t3 is the "latest" calculated sequence member, while t2 is the previous "latest" member
    	
    	# Print the latest sequence member in t3
	li $v0, 1		# Signal the syscall to print an integer
	move $a0, $t3		# Write t3 to the argument register, to be used by the syscall
	syscall			# Print the result
    	
        addi $t0, $t0, 1    	# Increment the loop counter (number of iterations we've completed)
        bne $t0, $t1, addsep  	# If there are more numbers to print (if the loop counter is not equal to the upper limit), add a separator
        
    	li $v0, 10          	# Set v0 register to system exit call code
    	syscall			# Exit

    addsep:	# Subroutine to print the separator text
    	li $v0, 4		# Signal the syscall that we want to print a string
    	la $a0, separator	# Write the separator text to the argument register
    	syscall			# Print the separator
    	j loop			# Jump back to the main loop

    .end main
