// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ImportViewController : NSViewController {
	NSButton *_import_Click;
	NSProgressIndicator *_importProgressBar;
	NSTextField *_lblProgress;
	NSTextView *_txtImportLog;
	NSTextField *_txtLogs;
}

@property (nonatomic, retain) IBOutlet NSButton *import_Click;

@property (nonatomic, retain) IBOutlet NSProgressIndicator *importProgressBar;

@property (nonatomic, retain) IBOutlet NSTextField *lblProgress;

@property (nonatomic, retain) IBOutlet NSTextView *txtImportLog;

@property (nonatomic, retain) IBOutlet NSTextField *txtLogs;

- (IBAction)importClicked:(id)sender;

@end
