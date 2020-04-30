import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { PortfolioFormComponent } from './portfolio/portfolio-form/portfolio-form.component';
import { PortfolioViewComponent } from './portfolio/portfolio-view/portfolio-view.component';
import { PortfolioListComponent } from './portfolio/portfolio-list/portfolio-list.component';
import { PropertyDashboardComponent } from './property/property-dashboard/property-dashboard.component';
import { PropertyFormComponent } from './property/property-form/property-form.component';
import { PropertyViewComponent } from './property/property-view/property-view.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { TenantFormComponent } from './tenant/tenant-form/tenant-form.component';
import { TenantViewComponent } from './tenant/tenant-view/tenant-view.component';
import { TenantListComponent } from './tenant/tenant-list/tenant-list.component';
import { PropertyDocumentFormComponent } from './property-document/property-document-form/property-document-form.component';
import { PropertyDocumentViewComponent } from './property-document/property-document-view/property-document-view.component';
import { PropertyDocumentListComponent } from './property-document/property-document-list/property-document-list.component';
import { PortfolioDashboardComponent } from './portfolio/portfolio-dashboard/portfolio-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PortfolioFormComponent,
    PortfolioViewComponent,
    PortfolioListComponent,
    PropertyDashboardComponent,
    PropertyFormComponent,
    PropertyViewComponent,
    PropertyListComponent,
    TenantFormComponent,
    TenantViewComponent,
    TenantListComponent,
    PropertyDocumentFormComponent,
    PropertyDocumentViewComponent,
    PropertyDocumentListComponent,
    PortfolioDashboardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      {
        path: 'portfolios', canActivate: [AuthorizeGuard], children: [
          { path: '', component: PortfolioDashboardComponent },
          { path: 'create', component: PortfolioFormComponent },
          { path: ':portfolioId', component: PortfolioViewComponent },
          { path: 'edit/:portfolioId', component: PortfolioFormComponent },
          
        ]
      },
      {
        path: 'property', canActivate: [AuthorizeGuard], children: [
          //{ path: '', component: PropertyDashboardComponent },
          { path: 'create', component: PropertyFormComponent },
          { path: ':propertyId', component: PropertyViewComponent },
          { path: 'edit/:propertyId', component: PropertyFormComponent },

        ]
      },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
