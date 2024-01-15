import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerPlayerListComponent } from './player-player-list.component';

describe('PlayerPlayerListComponent', () => {
  let component: PlayerPlayerListComponent;
  let fixture: ComponentFixture<PlayerPlayerListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlayerPlayerListComponent]
    });
    fixture = TestBed.createComponent(PlayerPlayerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
