import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerEventsAddComponent } from './manager-events-add.component';

describe('ManagerEventsAddComponent', () => {
  let component: ManagerEventsAddComponent;
  let fixture: ComponentFixture<ManagerEventsAddComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ManagerEventsAddComponent]
    });
    fixture = TestBed.createComponent(ManagerEventsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
