.model flat, stdcall
option casemap:none

.data
    vector      DWORD 0, 0, 0, 0          ; Placeholder for 4 DWORD parameters (vector elements)
    exponent    DWORD 0                    ; Exponent parameter

.code
    PUBLIC asm_power

asm_power PROC
    mov ecx, [exponent]                 ; Load the exponent into ecx
    movdqu xmm0, [vector]               ; Load 4 DWORD parameters (vector elements) into xmm0
    movaps xmm1, xmm0                   ; Copy the vector elements to xmm1

    ; Calculate xmm0 ^ ecx (raise each element in xmm0 to the power of ecx)
    power_loop:
        dec ecx                         ; Decrement loop counter
        jz  done                        ; If ecx is zero, jump to the end of the loop
        imulps xmm0, xmm1               ; Multiply xmm0 by xmm1 (result in xmm0)
        jmp power_loop

    done:
    ; The result is in xmm0
    movd [result], xmm0                ; Store the result in the result variable
    ret
asm_power ENDP

END
