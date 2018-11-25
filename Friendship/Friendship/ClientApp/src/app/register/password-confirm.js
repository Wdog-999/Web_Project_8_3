"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function checkPasswords(group) {
    var pass = group.controls.Password.value;
    var confirmPass = group.controls.CPassword.value;
    return pass === confirmPass ? null : { notSame: true };
}
exports.checkPasswords = checkPasswords;
//# sourceMappingURL=password-confirm.js.map