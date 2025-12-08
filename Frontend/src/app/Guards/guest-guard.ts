import { CanActivateFn } from '@angular/router';
import { UserService } from '../Services/user-service';
import { inject } from '@angular/core';
import { Constants } from '../Constants';

export const guestGuard: CanActivateFn = (route, state) => {
  const userService=inject(UserService);

  return userService.userSignal().roles.includes(Constants.Roles.Guest);
};
