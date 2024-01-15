import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerNavbarComponent } from './player-navbar.component';

describe('PlayerNavbarComponent', () => {
  let component: PlayerNavbarComponent;
  let fixture: ComponentFixture<PlayerNavbarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlayerNavbarComponent]
    });
    fixture = TestBed.createComponent(PlayerNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
