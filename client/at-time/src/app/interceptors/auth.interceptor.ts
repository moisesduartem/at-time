import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {

    }

    public intercept(request: HttpRequest<any>, next: HttpHandler) {
        const jwt = this.authService.token;
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${jwt}`
            }
        });

        return next.handle(request);
    }
}