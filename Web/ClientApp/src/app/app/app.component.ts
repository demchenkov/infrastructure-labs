import { Component, OnInit } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {
  routeAnimations,
  LocalStorageService,
  TitleService,
} from '../core/core.module';
import {filter, map} from "rxjs/operators";
import {AuthorizeService} from "../core/api-authorization/authorize.service";
import { OverlayContainer } from '@angular/cdk/overlay';
import { ActivatedRoute, ActivationEnd, Router } from '@angular/router';

@Component({
  selector: 'sb-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [routeAnimations]
})
export class AppComponent implements OnInit {
  year = new Date().getFullYear();
  logo = './logo.png';

  navigation = [
    { link: 'cars', label: 'Cars'},
    { link: 'customers', label: 'Customers'},
    { link: 'employees', label: 'Employees'},
    { link: 'about', label: 'About' },
  ];

  navigationSideMenu = [
    ...this.navigation,
    { link: 'settings', label: 'sb.menu.settings' }
  ];

  isAuthenticated$: Observable<boolean>;
  stickyHeader$: Observable<boolean>;
  language$: Observable<string>;
  theme$ = new BehaviorSubject('nature-theme');
  username$: Observable<string>;

  constructor(
    private storageService: LocalStorageService,
    private authorizeService: AuthorizeService,
    private overlayContainer: OverlayContainer,
    private titleService: TitleService,
    private router: Router,
  ) {
    this.isAuthenticated$ = this.authorizeService.isAuthenticated();
    this.username$ = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }

  ngOnInit(): void {
    this.router.events.pipe(
      filter((event) => event instanceof ActivationEnd)
    ).subscribe(() => {
      this.titleService.setTitle(
        this.router.routerState.snapshot.root,
      );
    })
    this.theme$.subscribe(x => {
      this.overlayContainer.getContainerElement().classList.add(x);
    });
  }

  onLoginClick() {
    // this.store.dispatch(authLogin());
  }

  onLogoutClick() {
    // this.store.dispatch(authLogout());
  }

  onLanguageSelect({ value: language }) {
    // this.store.dispatch(actionSettingsChangeLanguage({ language }));
  }
}
