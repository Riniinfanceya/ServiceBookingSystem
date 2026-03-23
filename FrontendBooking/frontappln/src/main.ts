import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { App } from './app/app';
import { routes } from './app/app.routes';
import { JwtInterceptor } from './app/interceptors/jwt.interceptor';
import { provideRouter } from '@angular/router';

bootstrapApplication(App, {
  providers: [
    provideHttpClient(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    provideRouter(routes)   // ✅ register routes here
  ]
}).catch((err) => console.error(err));
