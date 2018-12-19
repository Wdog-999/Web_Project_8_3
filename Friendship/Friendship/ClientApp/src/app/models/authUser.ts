import { User } from "./user";

export interface AuthUser
{ 
    tokenString: string; 
  user: User;
  id: string;
  name: string;
}
