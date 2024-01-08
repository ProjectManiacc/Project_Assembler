.code
ALIGN 16

PUBLIC asm_power
asm_power PROC base:DWORD, exponent:DWORD
    mov eax, 1         ; Initialize the result to 1

    ; Handling the power operation (base^exponent)
    mov ecx, exponent  ; Load the exponent into ecx

power_loop:
    cmp ecx, 0          ; Check if the exponent is equal to 0
    je  power_done      ; If yes, exit the loop with result 1

    imul eax, base      ; Multiply the result by the base
    dec ecx             ; Decrement the exponent
    jmp power_loop      ; Repeat the loop

power_done:
    ; The result of the power operation is stored in the eax register
    ret
asm_power ENDP

END
