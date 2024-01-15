import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionPanelDeleteComponent } from './selection-panel-delete.component';

describe('SelectionPanelDeleteComponent', () => {
  let component: SelectionPanelDeleteComponent;
  let fixture: ComponentFixture<SelectionPanelDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SelectionPanelDeleteComponent]
    });
    fixture = TestBed.createComponent(SelectionPanelDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
