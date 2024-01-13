.code
ALIGN 16

PUBLIC asm_power
asm_power PROC base:QWORD, exponent:QWORD
    mov rax, 1         ; Initialize the result to 1

    ; Handling the power operation (base^exponent)
    mov rcx, exponent  ; Load the exponent into rcx

power_loop:
    cmp rcx, 0          ; Check if the exponent is equal to 0
    je  power_done      ; If yes, exit the loop with result 1

    imul rax, base      ; Multiply the result by the base
    dec rcx             ; Decrement the exponent
    jmp power_loop      ; Repeat the loop

power_done:
    ; The result of the power operation is stored in the rax register
    ret
asm_power ENDP

END
