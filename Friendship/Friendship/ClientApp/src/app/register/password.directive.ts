import { Directive } from '@angular/core';
import { NG_VALIDATORS } from '@angular/forms';
import { checkPasswords } from './password-confirm';

@Directive({
  selector: '[checkPasswords][ngModel]',
  providers: [
    { provide: NG_VALIDATORS, useValue: checkPasswords, multi: true }
  ]
})
export class PasswordValidator {}
