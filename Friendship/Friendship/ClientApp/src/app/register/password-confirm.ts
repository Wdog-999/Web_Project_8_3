import { FormGroup } from '@angular/forms';

export function checkPasswords(group: FormGroup) {
  let pass = group.controls.Password.value;
  let confirmPass = group.controls.CPassword.value;

  return pass === confirmPass ? null : { notSame: true }
}
