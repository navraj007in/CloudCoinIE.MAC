// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ExportViewController : NSViewController {
    
    
    IBOutlet NSTextField *lblHeader;
    IBOutlet NSTextField *lblTwoFiftiesTotal;
    IBOutlet NSTextField *lblHundredsTotal;
    IBOutlet NSTextField *lblQtrsTotal;
    IBOutlet NSTextField *lblFivesTotal;
    IBOutlet NSTextField *lblOnesTotal;
    IBOutlet NSTextField *countFives;
    IBOutlet NSTextField *countOnes;
    IBOutlet NSTextField *countQtrs;
    IBOutlet NSTextField *countHundreds;
    IBOutlet NSTextField *countTwoFifties;
    IBOutlet NSStepper *stepperOnes;
    IBOutlet NSStepper *stepperFives;
    IBOutlet NSStepper *stepperQtrs;
    IBOutlet NSStepper *stepperHundreds;
    IBOutlet NSStepper *stepperTwoFifties;

    IBOutlet NSButton *rdbStack;
    IBOutlet NSButton *rdbJpeg;
    IBOutlet NSTextField *txtTag;
}
- (IBAction)stackClicked:(id)sender;
- (IBAction)jpegClick:(id)sender;
- (IBAction)exportClicked:(id)sender;
- (IBAction)oneClicked:(id)sender;
- (IBAction)fiveClicked:(id)sender;
- (IBAction)qtrClicked:(id)sender;
- (IBAction)hundredClicked:(id)sender;
- (IBAction)twoFiftyClicked:(id)sender;

@end
