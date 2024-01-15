import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerPlayerStatisticsComponent } from './player-player-statistics.component';

describe('PlayerPlayerStatisticsComponent', () => {
  let component: PlayerPlayerStatisticsComponent;
  let fixture: ComponentFixture<PlayerPlayerStatisticsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PlayerPlayerStatisticsComponent]
    });
    fixture = TestBed.createComponent(PlayerPlayerStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
