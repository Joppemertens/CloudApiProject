import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DelijnComponent } from './delijn.component';

describe('DelijnComponent', () => {
  let component: DelijnComponent;
  let fixture: ComponentFixture<DelijnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DelijnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DelijnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
