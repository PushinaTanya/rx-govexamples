﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using GD.MainSolution.DocumentReviewTask;

namespace GD.MainSolution
{
  partial class DocumentReviewTaskSharedHandlers
  {

    public override void DocumentForReviewGroupDeleted(Sungero.Workflow.Interfaces.AttachmentDeletedEventArgs e)
    {
      base.DocumentForReviewGroupDeleted(e);
      foreach (var relatedDoc in _obj.OtherGroup.All)
        _obj.OtherGroup.All.Remove(relatedDoc);
    }

    public override void DocumentForReviewGroupAdded(Sungero.Workflow.Interfaces.AttachmentAddedEventArgs e)
    {
      base.DocumentForReviewGroupAdded(e);
      var document = Sungero.Docflow.OfficialDocuments.As(e.Attachment);
      if (IncomingDocumentBases.Is(document))
        Functions.Module.AddRelationToAddendum(_obj.OtherGroup, document);
    }

  }
}